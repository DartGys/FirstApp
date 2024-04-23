namespace TaskBoard.DAL.Data.Entities;

public class Priority
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Card> Cards { get; set; }
}