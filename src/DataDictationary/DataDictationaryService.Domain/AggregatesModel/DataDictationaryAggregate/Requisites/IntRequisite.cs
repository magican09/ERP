namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

public class IntRequisite : Requisite<int>
{
    public IntRequisite(string name, int value) : base(name, value)
    {
    }

}