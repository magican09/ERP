using System.Reflection;

namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate;

public class DataDictationary : Entity, IAggregateRoot
{
    private List<DataDictationaryRecordItem> _dataDictationaryRecordItems;
    private List<RequisiteDiscription> _requisiteDiscriptions;
  
    #region Properties
    public string Name { get; private set; }
    public IReadOnlyCollection<RequisiteDiscription> RequisiteDiscriptions  => _requisiteDiscriptions.AsReadOnly();
    public IReadOnlyCollection<DataDictationaryRecordItem> DataDictationaryRecordItems =>_dataDictationaryRecordItems.AsReadOnly();
    public DataDictationaryStatus DictationaryStatus { get; private set; }

    #endregion

    #region Constructors
    protected DataDictationary()
    {
        _dataDictationaryRecordItems = new List<DataDictationaryRecordItem>();
        _requisiteDiscriptions = new List<RequisiteDiscription>();
    }
    public DataDictationary(string name) : this()
    {
        Name = name;
        DictationaryStatus = DataDictationaryStatus.Created;
    }
#endregion

    #region Public Methods
    
    public void AddRecordItem()
    {
       var  recordItem = new DataDictationaryRecordItem();
        
        var existRecordItem = _dataDictationaryRecordItems.SingleOrDefault(x => x.Id == recordItem.Id && 
            x.Id!= 0);

        if (existRecordItem == null)
        {
            
            foreach (RequisiteDiscription req_desc in _requisiteDiscriptions)
            {
                var req_default_value = GetDeafaultValue(req_desc.ValueType);
              
                var new_requisite =(IRequisite)
                                   Activator.CreateInstance(req_desc.Type, new[] { req_desc.Name,req_default_value});
             
                recordItem.AddRequisite(new_requisite);
            }
            
            _dataDictationaryRecordItems.Add(recordItem);
        }
    }

    public void AddRequisite(IRequisite requisite)
    {
        var exist_req_desc = _requisiteDiscriptions
            ?.FirstOrDefault(rd => rd.Name == requisite.Name);
        
        if(exist_req_desc != null)
            throw new DataDictationaryDomainExecption($"Field with name {requisite.Name} already exist");
        else
            _requisiteDiscriptions?.Add( new RequisiteDiscription(requisite));
      
        foreach (DataDictationaryRecordItem record in _dataDictationaryRecordItems)
        {
           record.AddRequisite(requisite);
           _requisiteDiscriptions?.Add(new RequisiteDiscription(requisite));
        }
        
    }

    public void AddRequisite(string requisiteName, Type requisiteType)
    {
       var requisite_value_type = requisiteType.BaseType?.GetGenericArguments()[0];

       if (requisite_value_type != null)
       {
           var requisite_val = GetDeafaultValue(requisite_value_type);
       
           var moc_requisite =(IRequisite) Activator.CreateInstance(requisiteType, new object[] {requisiteName,requisite_val})!;
           this.AddRequisite(moc_requisite);
       }
    }

    
    public void DeleteRequisite(IRequisite requisite)
    {
        foreach (DataDictationaryRecordItem record in _dataDictationaryRecordItems)
        {
            record.DeleteRequisite(requisite);
            var exist_req_desc = _requisiteDiscriptions
                ?.FirstOrDefault(rd => rd.Name == requisite.Name && rd.GetType() == requisite.Type);
            if(exist_req_desc != null)
                _requisiteDiscriptions.Remove(exist_req_desc);

        }
        
    }

    
    #endregion

  
}