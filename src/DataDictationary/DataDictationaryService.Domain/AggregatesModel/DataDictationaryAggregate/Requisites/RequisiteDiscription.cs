namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

public class RequisiteDiscription:Entity
{
    private static int _currentRequisiteNumber = 0;
   // public int Number { get; private set;  }
    public string Name { get; private set;  }
    public Type Type { get;   }
    
    public Type ValueType { get;   }
    
   // public object? DefaultValue { get;   }

    protected RequisiteDiscription()
    {
     //   Number = _currentRequisiteNumber++;
    }

    public RequisiteDiscription(string name,Type valueType, Type type) : this()
    {
            ValueType = valueType;
            Name = name;
             Type = type;
    }

    public RequisiteDiscription(IRequisite requisite):this(requisite.Name,requisite.ValueType,requisite.Type) 
    {
            requisite.Discription = this;
    }
    /*protected override IEnumerable<object> GetEqualityComponents()
    {
     yield return Name;
     yield return Type;
     yield return ValueType;
    }*/
}