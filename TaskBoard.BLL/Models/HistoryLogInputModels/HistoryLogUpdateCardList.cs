namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardList
{
    public Guid CardId { get; set; }
    public static string CardName { get; set; }
    public static string PreviousCardList { get; set; }
    public static string NewCardList { get; set; }
    public string ChangeDescription { get; private set; } =
        $"You moved <strong>{CardName}</strong> from <strong>{PreviousCardList}</strong> to strong>{NewCardList}</strong>";
}