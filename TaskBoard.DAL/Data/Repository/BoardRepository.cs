using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class BoardRepository : GenericRepository<Board>, IBoardRepository
{
    public BoardRepository(ApplicationDbContext context) : base(context) { }

    public int GetCardCount(Guid id)
    {
        return _context.Cards.Where(x => x.BoardId == id).AsNoTracking().Count();
    }
    
    public int GetCardListCount(Guid id)
    {
        return _context.CardLists.Where(x => x.BoardId == id).AsNoTracking().Count();
    }
}