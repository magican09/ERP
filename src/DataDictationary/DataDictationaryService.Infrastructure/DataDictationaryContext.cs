using DataDictationaryService.Domain.SeedWork;
using DataDictationaryService.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataDictationaryService.Infrastructure;

public class DataDictationaryContext:DbContext,IUnitOfWork
{
    public DbSet<DataDictationary> DataDictationaries { get; set; }
    public DbSet<DataDictationaryRecordItem> DataDictationaryRecordItems { get; set; }
    
    private readonly IMediator _mediator;
    private IDbContextTransaction _contextTransaction;

    public DataDictationaryContext()
    {
     Database.EnsureDeleted();
     Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;TrustServerCertificate=True;Database=dict_db;User=sa;MultipleActiveResultSets = Yes; Password=aA26497852)");
        base.OnConfiguring(optionsBuilder);
    }

    public DataDictationaryContext(DbContextOptions<DataDictationaryContext> options) : base(options)
    {
       
    }
    
    public DataDictationaryContext(DbContextOptions<DataDictationaryContext> options, IMediator mediator)
    {
            _mediator = mediator??throw new ArgumentNullException(nameof(mediator));
            
            System.Diagnostics.Debug.WriteLine("DataDictationaryContext::ctor ->" + this.GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.HasDefaultSchema("dictationary_service");
       modelBuilder.ApplyConfiguration(new DataDictationaryEntityTypeConfiguration());
       modelBuilder.ApplyConfiguration(new DataDictationaryRecordItemEntityTypeConfiguration());
       //modelBuilder.ApplyConfiguration(new RequisiteDescriptionEntityTypeConfiguratioin());

    }

    public   Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        //_ = await base.SaveChangesAsync(cancellationToken);
        SaveChanges();
        return Task.FromResult(true);
    }
}