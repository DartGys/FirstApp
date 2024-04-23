using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Data.Configurations;

public class HistoryLogConfiguration : IEntityTypeConfiguration<HistoryLog>
{
    public void Configure(EntityTypeBuilder<HistoryLog> builder)
    {
        builder.HasNoKey();

        builder.Property(h => h.ChangeDescription)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(h => h.ChangeDate)
            .IsRequired();
    }
}