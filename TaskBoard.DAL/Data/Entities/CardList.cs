using TaskBoard.DAL.Data.Repository;

namespace TaskBoard.DAL.Data.Entities;

public class CardList : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BoardId { get; set; }
    public Board Board { get; set; }
    public virtual ICollection<Card> Cards { get; set; }
}