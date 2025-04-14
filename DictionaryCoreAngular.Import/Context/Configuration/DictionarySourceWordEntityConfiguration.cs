using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class DictionarySourceWordEntityConfiguration : IEntityTypeConfiguration<DictionarySourceWord>
    {
        public void Configure(EntityTypeBuilder<DictionarySourceWord> builder)
        {
            builder.ToTable("DictionarySourceWord");

            builder.HasOne(s => s.DictionarySource)
            .WithMany(g => g.DictionarySourceWords)
            .HasForeignKey(s => s.DictionarySourceId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Word)
            .WithMany(g => g.DictionarySourceWords)
            .HasForeignKey(s => s.WordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(b => new { b.WordId, b.DictionarySourceId} ).IsUnique();

        }
    }
}
