using TaskBoard.DAL.Data.Repository;

namespace TaskBoard.DAL.Data.Entities;

public class Card : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public Guid PriorityId { get; set; }
    public Priority Priority { get; set; }
    public Guid CardListId { get; set; }
    public CardList CardList { get; set; }
    public Guid BoardId { get; set; }
    public Board Board { get; set; }
    public virtual ICollection<HistoryLog> HistoryLogs { get; set; }
}