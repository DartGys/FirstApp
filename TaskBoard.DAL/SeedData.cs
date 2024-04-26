using TaskBoard.DAL.Data;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL;

public class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.Priorities.Any()) return;
        else
        {
            context.Priorities.AddRange(
                new Priority { Id = Guid.NewGuid(), Name = "Low" },
                new Priority { Id = Guid.NewGuid(), Name = "Standart" },
                new Priority { Id = Guid.NewGuid(), Name = "High" }
            );
            context.SaveChanges();
        }
    }
}