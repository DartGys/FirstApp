using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Card> Cards => Set<Card>();
    public DbSet<HistoryLog> HistoryLogs => Set<HistoryLog>();
    public DbSet<CardList> CardLists => Set<CardList>();
    public DbSet<Priority> Priorities => Set<Priority>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}