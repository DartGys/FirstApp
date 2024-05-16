using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Interfaces.Repository;

public interface IBoardRepository : IGenericRepository<Board>
{
    int GetCardCount(Guid id);
    int GetCardListCount(Guid id);
}