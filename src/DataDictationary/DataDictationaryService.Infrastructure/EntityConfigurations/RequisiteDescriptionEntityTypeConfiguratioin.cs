using DataDictationaryService.Domain.AggregatesModel.DataDictationaryAggregate.Requisites;

namespace DataDictationaryService.Infrastructure.EntityConfigurations;

public class RequisiteDescriptionEntityTypeConfiguratioin:IEntityTypeConfiguration<RequisiteDiscription>
{
    public void Configure(EntityTypeBuilder<RequisiteDiscription> builder)
    {
        builder.ToTable("RequisiteDescriptions");

        builder.Property(d => d.Type)
            .HasConversion(
                v => v.ToString(),
                v => (Type)Enum.Parse(typeof(Type), v));
        
        builder.Property(d => d.ValueType)
            .HasConversion(
                v => v.ToString(),
                v => (Type)Enum.Parse(typeof(Type), v));
    }
}