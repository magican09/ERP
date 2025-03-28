namespace DataDictationaryService.gRPC.Application.Queries;

public record IntRequisite
{
    public int RequisiteNumber { get; init; }
    public string Name { get; init; }
    public string Type { get; init; }
    public int Value { get; init; }   
}
public record DecimalRequisite
{
public int RequisiteNumber { get; init; }
public string Name { get; init; }
//public string Type { get; init; }
public decimal Value { get; init; }   
}
public record StringRequisite
{
public int RequisiteNumber { get; init; }
public string Name { get; init; }
//public string Type { get; init; }
public string Value { get; init; }   
}

public record DataDictationaryItemRequisite
{
    public int RequisiteNumber { get; init; }
    public string Name { get; init; }
  //  public string Type { get; init; }
    public int Value { get; init; }   
}

public record DataDictationaryRecordItem
{
    public int ItemNumber { get; init; }
    public string Name { get; init; }
    public List<IntRequisite> IntRequisites { get; init; }
    public List<DecimalRequisite> DecimalRequisites { get; init; }
    public List<StringRequisite> StringRequisites { get; init; }
    public List<DataDictationaryItemRequisite> DataDictationaryItems { get; init; }
}

public record RequisiteDescription
{
     public int DescriptionNumber { get; init; }
     public string Name { get; init; }
     public Type Type { get; init; } 
}

public record DataDictationary
{
    public int DictationaryNumber { get; init; }
    public string Name { get; init; }
    public List<RequisiteDescription> RequisiteDescriptions { get; init; }
    public List<DataDictationaryRecordItem> RecordItems { get; init; }
}