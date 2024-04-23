using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class HistoryLogRepository : GenericRepository<HistoryLog>, IHistoryLogRepository
{
    public HistoryLogRepository(ApplicationDbContext context) : base(context) { }
}