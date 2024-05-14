using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class BoardRepository : GenericRepository<Board>, IBoardRepository
{
    public BoardRepository(ApplicationDbContext context) : base(context) { }
}