namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public abstract class HistoryLogInputModel
{
    public HistoryLogInputModel(Guid cardId, string cardName)
    {
        CardId = cardId;
        CardName = cardName;
    }

    public HistoryLogInputModel() { }

    public Guid CardId { get; set; }
    public string CardName { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;
}