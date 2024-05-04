using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Interfaces.Repository;

public interface ICardRepository : IGenericRepository<Card>
{
    Task UpdateCardList(Guid id, Guid listId);
    Task UpdateEntity(Card entity);
}