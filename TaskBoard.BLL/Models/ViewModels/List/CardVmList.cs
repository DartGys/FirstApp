namespace TaskBoard.BLL.Models.ViewModels.List;

public class CardVmList
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string PriorityName { get; set; }
    public Guid CardListId { get; set; }
}