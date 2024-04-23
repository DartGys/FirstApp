using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class PriorityRepository : GenericRepository<Priority>, IPriorityRepository
{
    public PriorityRepository(ApplicationDbContext context) : base(context) { }
}