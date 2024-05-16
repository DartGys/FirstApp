using TaskBoard.DAL.Data.Repository;

namespace TaskBoard.DAL.Data.Entities;

public class Board : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Card> Cards { get; set; }
    public virtual ICollection<CardList> CardLists { get; set; }
    public virtual ICollection<HistoryLog> HistoryLogs { get; set; }
}