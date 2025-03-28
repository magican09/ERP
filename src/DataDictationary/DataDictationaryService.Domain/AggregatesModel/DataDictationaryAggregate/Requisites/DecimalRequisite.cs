namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

public class DecimalRequisite:Requisite<decimal>
{
    public DecimalRequisite(string name, decimal value):base(name, value){ }

    public DecimalRequisite(string name, int value) : base(name, Convert.ToDecimal(value)){ }


}