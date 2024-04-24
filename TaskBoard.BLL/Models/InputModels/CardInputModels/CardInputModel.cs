namespace TaskBoard.BLL.Models.InputModels;

public class CardInputModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public Guid PriorityId { get; set; }
    public Guid CardListId { get; set; }
}