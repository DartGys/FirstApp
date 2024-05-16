using TaskBoard.DAL.Data.Repository;
using TaskBoard.DAL.Interfaces;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context) 
    {
        _context = context;
        Card = new CardRepository(context);
        CardList = new CardListRepository(context);
        HistoryLog = new HistoryLogRepository(context);
        Priority = new PriorityRepository(context);
        Board = new BoardRepository(context);
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public ICardRepository Card { get; private set; }
    public ICardListRepository CardList { get; private set; }
    public IHistoryLogRepository HistoryLog { get; private set; }
    public IPriorityRepository Priority { get; private set; }
    public IBoardRepository Board { get; private set; }
    
    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}