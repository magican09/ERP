namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

public abstract class Requisite<T>:Entity,IRequisite<T> 
{
    public T? Value { get; private set; }

    public string Name { get; private set; }
    public Requisite() { }
    
    public  Requisite(string name,T value):this()
    {
           Name = name;
           Value = value;
    }
    public Type ValueType => typeof(T);

    public Type Type => this.GetType();
   
    public RequisiteDiscription Discription { get;  set; }

   
}