
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class WordListWordEntityConfiguration : IEntityTypeConfiguration<WordListWord>
    {
        public void Configure(EntityTypeBuilder<WordListWord> builder)
        {
            builder.HasKey(e => e.WordListWordId);
            builder.ToTable("WordListWord");

            builder.HasOne(x => x.Word)
            .WithMany(x => x.WordListWords)
            .HasForeignKey(x => x.WordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.WordList)
            .WithMany(x => x.WordListWords)
            .HasForeignKey(x => x.WordListId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordStatuses)
                .WithOne(s => s.WordListWord)
                .HasForeignKey(s => s.WordListWordId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.StepWords)
                .WithOne(s => s.WordListWord)
                .HasForeignKey(s => s.WordListWordId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
