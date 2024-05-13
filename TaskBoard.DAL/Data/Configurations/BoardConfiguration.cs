using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Data.Configurations;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasMany(x => x.Cards)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.CardLists)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.HistoryLogs)
            .WithOne(h => h.Board)
            .HasForeignKey(h => h.BoardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}