
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class WordListEntityConfiguration : IEntityTypeConfiguration<WordList>
    {
        public void Configure(EntityTypeBuilder<WordList> builder)
        {
            builder.HasKey(e => e.WordListId);
            builder.ToTable("WordList");

            builder.HasOne(x => x.WordListGroup)
            .WithMany(x => x.WordLists)
            .HasForeignKey(x => x.WordListGroupId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.Histories)
                .WithOne(s => s.WordList)
                .HasForeignKey(s => s.WordListId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.WordListWords)
                .WithOne(s => s.WordList)
                .HasForeignKey(s => s.WordListId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
