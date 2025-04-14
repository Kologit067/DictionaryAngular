using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class WordEntityConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(e => e.WordId);
            builder.Property(e => e.WordId).IsRequired(true).ValueGeneratedOnAdd();
            builder.ToTable("Word");

            builder.HasOne(x => x.Dictionary)
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.DictionaryId).OnDelete(DeleteBehavior.SetNull);

            builder.Property(b => b.Transcription).HasMaxLength(500).IsRequired(false);

            builder.HasMany(g => g.DictionarySourceWords)
                .WithOne(s => s.Word)
                .HasForeignKey(s => s.WordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.Translations)
                .WithOne(s => s.Word)
                .HasForeignKey(s => s.WordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordListWords)
                .WithOne(s => s.Word)
                .HasForeignKey(s => s.WordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(b => new {b.WordText, b.DictionaryId}).IsUnique();
        }
    }
}
