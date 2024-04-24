using TaskBoard.BLL.Models.ViewModels.List;

namespace TaskBoard.BLL.Models.ViewModels.Details;

public class CardVmDetails
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public string PriorityName { get; set; }
    public Guid CardListId { get; set; }
    public IReadOnlyList<HistoryLogVm> HistoryLogs { get; set; }
}