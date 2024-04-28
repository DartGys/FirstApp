using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL.Interfaces.Repository;

public interface ICardRepository : IGenericRepository<Card>
{
    Task UpdateCardList(Guid id, Guid listId);
    Task UpdateCardPriority(Guid id, Guid priorityId);
    Task UpdateEntity(Guid id, string name, string description, DateTime dueDate);
}