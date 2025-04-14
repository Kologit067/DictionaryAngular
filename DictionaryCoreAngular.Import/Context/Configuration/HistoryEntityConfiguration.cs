
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DictionaryCoreAngular.Import.Context.Configuration
{
    public class HistoryEntityConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(e => e.HistoryId);
            builder.ToTable("History");

            builder.HasOne(x => x.User)
            .WithMany(x => x.Histories)
            .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.WordList)
            .WithMany(x => x.Histories)
            .HasForeignKey(x => x.WordListId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.ComparisonType)
            .WithMany(x => x.Histories)
            .HasForeignKey(x => x.ComparisonTypeId).OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.HistoryRounds)
                .WithOne(s => s.History)
                .HasForeignKey(s => s.HistoryId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
