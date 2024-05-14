using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class HistoryLogRepository : GenericRepository<HistoryLog>, IHistoryLogRepository
{
    public HistoryLogRepository(ApplicationDbContext context) : base(context) { }
    
    public async Task<IEnumerable<HistoryLog>> GetTwentyLogs(int lastRecord, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.HistoryLogs
            .AsNoTracking()
            .OrderByDescending(log => log.ChangeDate) 
            .Skip(lastRecord) 
            .Take(20) 
            .ToListAsync(cancellationToken); 
    }
    
    public async Task<IEnumerable<HistoryLog>> GetTwentyLogsByBoard(Guid boardId, int lastRecord, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.HistoryLogs
            .AsNoTracking()
            .Where(x => x.BoardId == boardId)
            .OrderByDescending(log => log.ChangeDate) 
            .Skip(lastRecord) 
            .Take(20) 
            .ToListAsync(cancellationToken); 
    }
}