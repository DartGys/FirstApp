using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Data.Configurations;

public class CardListConfiguration : IEntityTypeConfiguration<CardList>
{
    public void Configure(EntityTypeBuilder<CardList> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasMany(c => c.Cards)
            .WithOne(c => c.CardList)
            .HasForeignKey(c => c.CardListId);
        
        builder.HasOne(c => c.Board)
            .WithMany(b => b.CardLists)
            .HasForeignKey(b => b.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}