namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate;

public interface IDataDictationaryRepository:IRepository<DataDictationary>
{
    DataDictationary Add(DataDictationary dictationary);
    void Update(DataDictationary dictationary);
    Task<DataDictationary> GetAsync(int id);
    
}