namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public abstract class HistoryLogInputModel
{
    public HistoryLogInputModel(Guid cardId)
    {
        CardId = cardId;
    }
    public Guid CardId { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;
}