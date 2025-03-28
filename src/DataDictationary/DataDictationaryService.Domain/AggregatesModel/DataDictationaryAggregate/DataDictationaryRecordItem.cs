using System.Collections;
using System.Reflection;
using DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;


namespace DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate;

public class DataDictationaryRecordItem:Entity
{
  #region Privat fields
  private List<IntRequisite> _intRequisites;
  private List<StringRequisite> _stringRequisites;
  private List<DecimalRequisite> _decimalRequisites;
  private List<DataDictationaryRecordItemRequisite> _dataDictationaryRecordItemRequisites;
  #endregion

  #region Propperties

  public IReadOnlyCollection<IntRequisite> IntRequisites => _intRequisites.AsReadOnly();
  public IReadOnlyCollection<StringRequisite> StringRequisites => _stringRequisites.AsReadOnly();
  public IReadOnlyCollection<DecimalRequisite> DecimalRequisites => _decimalRequisites.AsReadOnly();
  public IReadOnlyCollection<DataDictationaryRecordItemRequisite>  DictationaryRecordItemRequisites => _dataDictationaryRecordItemRequisites.AsReadOnly();
  #endregion
  
  #region Constructors
  internal DataDictationaryRecordItem()
  {
    _intRequisites = new List<IntRequisite>();
    _stringRequisites = new List<StringRequisite>();
    _decimalRequisites = new List<DecimalRequisite>();
    _dataDictationaryRecordItemRequisites = new List<DataDictationaryRecordItemRequisite>();
  }
#endregion
  #region Internal methods  
  internal void AddRequisite(IRequisite requisite)
{
  var fieldEntity = GetRequisiteFieldEntity(requisite);

  if (fieldEntity == null)
    throw new DataDictationaryDomainExecption($"Field with type {requisite.Type} does not supported");

    if(ContainsRequisiteWithName(fieldEntity, requisite.Name))
      throw new DataDictationaryDomainExecption($"Field with name {requisite.Name} already exist");
    fieldEntity.Add(requisite);
  }
  
  
internal void DeleteRequisite(IRequisite requisite)
{
  var fieldEntity = GetRequisiteFieldEntity(requisite);
 
  if (fieldEntity == null)
    throw new DataDictationaryDomainExecption($"Field with type {requisite.Type} does not supported");

  if(!ContainsRequisiteWithName(fieldEntity, requisite.Name))
    throw new DataDictationaryDomainExecption($"Field with name {requisite.Name} can not because not exist");

  fieldEntity.Remove(requisite);
}

  
  #endregion
  
  #region Private methods  
  private bool ContainsRequisiteWithName(IList requisites, string requisiteName)
  {
    foreach (var requsite  in requisites)
    {
      if ((requsite as IRequisite)?.Name == requisiteName)
        return true;
    }
    return false;
  }
  
  private  IList GetRequisiteFieldEntity(IRequisite requisite)
  {
    var field = this.GetType().GetFields(BindingFlags.NonPublic |
                                         BindingFlags.Static |
                                         BindingFlags.Instance)
      .FirstOrDefault(x => x.FieldType.Name == "List`1" && x.FieldType.GetGenericArguments()[0] == requisite.Type)
      ?.GetValue(this);
    return field as IList;
  }
  #endregion
}