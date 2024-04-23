namespace TaskBoard.DAL.Data.Entities;

public class Card
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public Guid PriorityId { get; set; }
    public Priority Priority { get; set; }
    public Guid ListId { get; set; }
    public List List { get; set; }
}