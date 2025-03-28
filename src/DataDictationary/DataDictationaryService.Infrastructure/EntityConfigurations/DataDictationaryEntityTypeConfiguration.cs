


using DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

namespace DataDictationaryService.Infrastructure.EntityConfigurations;

public class DataDictationaryEntityTypeConfiguration:IEntityTypeConfiguration<DataDictationary>
{
    public void Configure(EntityTypeBuilder<DataDictationary> dataDictationaryBuilder)
    {
        dataDictationaryBuilder.ToTable("data_dictationary");
        
        dataDictationaryBuilder.Ignore(o => o.DomainEvents);

        dataDictationaryBuilder.Property(o => o.Id)
            .UseHiLo("data_dictationary_seq");

        dataDictationaryBuilder
            .OwnsMany(p => p.RequisiteDiscriptions ,
                rd => 
                    rd.Property(p=>p.Type)
                        .HasConversion(
                            v=>v.ToString(),
                            v=>(Type)Enum.Parse(typeof(Type), v)
                           )
                        
                    )
            .OwnsMany(p => p.RequisiteDiscriptions ,
                rd => 
                    rd.Property(p=>p.ValueType)
                        .HasConversion(
                            v=>v.ToString(),
                            v=>(Type)Enum.Parse(typeof(Type), v)
                        )
            
                 )
            .OwnsMany(p => p.RequisiteDiscriptions,
                rd =>
                    rd.Ignore(p => p.DomainEvents));

    }
}