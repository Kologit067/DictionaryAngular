using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class DictionarySourceEntityConfiguration : IEntityTypeConfiguration<DictionarySource>
    {
        public void Configure(EntityTypeBuilder<DictionarySource> builder)
        {
            builder.ToTable("DictionarySource");

            builder.HasMany(g => g.DictionarySourceWords)
            .WithOne(s => s.DictionarySource)
            .HasForeignKey(s => s.DictionarySourceId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Dictionary)
            .WithMany(g => g.DictionarySources)
            .HasForeignKey(s => s.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.DictionaryTranslation)
            .WithMany(g => g.DictionarySourceTranslations)
            .HasForeignKey(s => s.DictionaryTranslationId).OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}
