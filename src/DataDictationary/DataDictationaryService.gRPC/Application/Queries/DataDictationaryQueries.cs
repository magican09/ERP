using DataDictationaryService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataDictationaryService.gRPC.Application.Queries;

public class DataDictationaryQueries(DataDictationaryContext context)
    :IDataDictationaryQueries
{
    public async Task<DataDictationary> GetDataDictationaryAsync(int id)
    {
        var dataDictationary = await context.DataDictationaries.FirstOrDefaultAsync(o=>o.Id == id);
        
        if(dataDictationary is null)
            throw  new KeyNotFoundException();

        int requisite_number = 0;
        return new DataDictationary()
        {
            DictationaryNumber = dataDictationary.Id,
            Name = dataDictationary.Name,
            RequisiteDescriptions = dataDictationary.RequisiteDiscriptions.Select(drd => new RequisiteDescription
            {
                DescriptionNumber = drd.Id,
                Name = drd.Name,
                Type = drd.Type
            }).ToList()
        };

    }
}