
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class ComparisonTypeEntityConfiguration : IEntityTypeConfiguration<ComparisonType>
    {
        public void Configure(EntityTypeBuilder<ComparisonType> builder)
        {
            builder.HasKey(e => e.ComparisonTypeId);
            builder.ToTable("ComparisonType");

            builder.HasMany(g => g.Histories)
                .WithOne(s => s.ComparisonType)
                .HasForeignKey(s => s.ComparisonTypeId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
