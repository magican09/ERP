namespace DataDictationaryService.Infrastructure.EntityConfigurations;

public class DataDictationaryRecordItemEntityTypeConfiguration:IEntityTypeConfiguration<DataDictationaryRecordItem>
{
    public void Configure(EntityTypeBuilder<DataDictationaryRecordItem> dictationaryRecordItemBuilder)
    {
        dictationaryRecordItemBuilder.ToTable("data_dictationary_record_items");
        
        dictationaryRecordItemBuilder.Ignore(o => o.DomainEvents);

        dictationaryRecordItemBuilder.Property(o => o.Id)
            .UseHiLo("data_dictationary_record_items_seq");
       
       
        dictationaryRecordItemBuilder
            .OwnsMany(o => o.IntRequisites,
                r=>
                   r.Ignore(o=>o.DomainEvents)
                   .Ignore(o=>o.Type)
                   .Ignore(o => o.ValueType)
                   .Ignore(o=>o.Discription));
      
        dictationaryRecordItemBuilder
            .OwnsMany(o => o.DecimalRequisites,
                r=>
                    r.Ignore(o=>o.DomainEvents)
                        .Ignore(o=>o.Type)
                        .Ignore(o => o.ValueType)
                        .Ignore(o=>o.Discription));
        
       
        dictationaryRecordItemBuilder
            .OwnsMany(o => o.StringRequisites,
                r=>
                    r.Ignore(o=>o.DomainEvents)
                        .Ignore(o=>o.Type)
                        .Ignore(o => o.ValueType)
                        .Ignore(o=>o.Discription));
        
       
        dictationaryRecordItemBuilder
            .OwnsMany(o => o.DictationaryRecordItemRequisites,
                r=>
                    r.Ignore(o=>o.DomainEvents)
                        .Ignore(o=>o.Type)
                        .Ignore(o => o.ValueType)
                        .Ignore(o=>o.Discription));
        
       
        
        
        
        
    }
}