namespace DataDictationaryService.Domain.Exeptions;
/// <summary>
/// Exeption type for domain exeptions
/// </summary>
public class DataDictationaryDomainExecption:Exception
{
    public DataDictationaryDomainExecption(){}

    public DataDictationaryDomainExecption(string message):base(message)
    {
            
    }

    public DataDictationaryDomainExecption(string message, Exception innerException):base(message,innerException)
    {
            
    }
}