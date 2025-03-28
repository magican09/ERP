using DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate;

namespace DataDictationaryService.gRPC.Application.Queries;

public interface IDataDictationaryQueries
{
    Task<DataDictationary> GetDataDictationaryAsync(int id);
    
}