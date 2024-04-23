using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class CardRepository : GenericRepository<Card>, ICardRepository
{
    public CardRepository(ApplicationDbContext context) : base(context) { }
}