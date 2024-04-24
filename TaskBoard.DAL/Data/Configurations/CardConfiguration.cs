using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Data.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        builder.Property(c => c.CreatedDate)
            .IsRequired();

        builder.Property(c => c.DueDate)
            .IsRequired();

        builder.HasOne(c => c.Priority)
            .WithMany(p => p.Cards)
            .HasForeignKey(c => c.PriorityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.CardList)
            .WithMany(c => c.Cards)
            .HasForeignKey(c => c.CardListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.HistoryLogs)
            .WithOne(h => h.Card)
            .HasForeignKey(h => h.CardId);
    }
}