namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;
public interface IRequisite   
{
    public string Name { get;  }
    public Type ValueType { get; }
    public Type Type { get; }
    public RequisiteDiscription Discription { get; set; }
    
  
}
public interface IRequisite<T> :IRequisite
{
   
    public T? Value { get;  }
    
}