namespace TaskBoard.BLL.Models.InputModels;

public class HistoryLogInputModel
{
    public string ChangeDescription { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;
    public Guid CardId { get; set; }
}