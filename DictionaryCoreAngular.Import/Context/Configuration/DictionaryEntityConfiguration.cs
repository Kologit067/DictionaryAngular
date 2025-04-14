using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class DictionaryEntityConfiguration : IEntityTypeConfiguration<Dictionary>
    {
        public void Configure(EntityTypeBuilder<Dictionary> builder)
        {
            builder.ToTable("Dictionary");

            builder.HasMany(g => g.Words)
            .WithOne(s => s.Dictionary)
            .HasForeignKey(s => s.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordListGroups)
            .WithOne(s => s.Dictionary)
            .HasForeignKey(s => s.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.Translations)
            .WithOne(s => s.Dictionary)
            .HasForeignKey(s => s.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.DictionarySources)
            .WithOne(s => s.Dictionary)
            .HasForeignKey(s => s.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.DictionarySourceTranslations)
            .WithOne(s => s.DictionaryTranslation)
            .HasForeignKey(s => s.DictionaryTranslationId).OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}
