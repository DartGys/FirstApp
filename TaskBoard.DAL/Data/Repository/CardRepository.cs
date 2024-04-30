using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.DAL.Data.Repository;

public class CardRepository : GenericRepository<Card>, ICardRepository
{
    public CardRepository(ApplicationDbContext context) : base(context) { }

    public async Task UpdateCardList(Guid id, Guid listId)
    {
        await _context.Cards.Where(x => x.Id == id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.CardListId, listId));
    }
    
    public async Task UpdateEntity(Guid id, string name, string description, DateTime dueDate, Guid priorityId, Guid listId)
    {
        await _context.Cards.Where(x => x.Id == id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.Name, name)
                .SetProperty(x => x.Description, description)
                .SetProperty(x => x.DueDate, dueDate)
                .SetProperty(x => x.PriorityId, priorityId)
                .SetProperty(x => x.CardListId, listId));
    }
}