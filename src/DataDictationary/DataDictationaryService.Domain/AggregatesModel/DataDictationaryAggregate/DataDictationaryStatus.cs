
namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DataDictationaryStatus
{
    Created =1,
    Updated = 2,
    Deleted = 3,
    InProgress = 4
}