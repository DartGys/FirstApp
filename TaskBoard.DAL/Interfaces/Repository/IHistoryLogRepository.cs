using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Interfaces.Repository;

public interface IHistoryLogRepository : IGenericRepository<HistoryLog>
{
    Task<IEnumerable<HistoryLog>> GetTwentyLogs(int lastRecord,
        CancellationToken cancellationToken = default(CancellationToken));
}