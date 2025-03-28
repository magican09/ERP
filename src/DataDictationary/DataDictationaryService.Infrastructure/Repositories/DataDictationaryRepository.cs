using DataDictationaryService.Domain.SeedWork;

namespace DataDictationaryService.Infrastructure.Repositories;

public class DataDictationaryRepository:IDataDictationaryRepository
{
    private readonly DataDictationaryContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public DataDictationaryRepository(DataDictationaryContext context)
    {
            _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public DataDictationary Add(DataDictationary dictationary)
    {
       return _context.DataDictationaries.Add(dictationary).Entity;
    }

    public void Update(DataDictationary dictationary)
    {
        _context.Entry(dictationary).State = EntityState.Modified;
    }

    public async Task<DataDictationary> GetAsync(int id)
    {
        var dictationary = await _context.DataDictationaries.FindAsync(id);

        if (dictationary != null) //загрузить все записи
        {
         //   await _context.Entry(dictationary)
          //      .Collection( i=>i.DataDictationaryRecordItems).LoadAsync();
          /*await _context.Entry(dictationary)
              .Collection(i => i.RequisiteDiscriptions).LoadAsync();*/
        }
        
        return dictationary;
    }
}