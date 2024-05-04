using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class CardListRepository : GenericRepository<CardList>, ICardListRepository
{
    public CardListRepository(ApplicationDbContext context) : base(context) { }
}