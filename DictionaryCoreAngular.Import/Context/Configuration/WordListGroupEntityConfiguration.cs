
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class WordListGroupEntityConfiguration : IEntityTypeConfiguration<WordListGroup>
    {
        public void Configure(EntityTypeBuilder<WordListGroup> builder)
        {
            builder.HasKey(e => e.WordListGroupId);
            builder.ToTable("WordListGroup");

            builder.HasOne(x => x.Dictionary)
            .WithMany(x => x.WordListGroups)
            .HasForeignKey(x => x.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordLists)
                .WithOne(s => s.WordListGroup)
                .HasForeignKey(s => s.WordListGroupId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
