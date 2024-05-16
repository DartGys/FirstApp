using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICardRepository Card { get; }
    ICardListRepository CardList { get; }
    IHistoryLogRepository HistoryLog { get; }
    IPriorityRepository Priority { get; }
    IBoardRepository Board { get;  }
    
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}