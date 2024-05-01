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
    
    public async Task UpdateEntity(Card entity)
    {
        await _context.Cards.Where(x => x.Id == entity.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(x => x.Name, entity.Name)
                .SetProperty(x => x.Description, entity.Description)
                .SetProperty(x => x.DueDate, entity.DueDate)
                .SetProperty(x => x.PriorityId, entity.PriorityId)
                .SetProperty(x => x.CardListId, entity.CardListId));
    }
}