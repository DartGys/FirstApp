namespace TaskBoard.DAL.Data.Entities;

public class HistoryLog
{
    public string ChangeDescription { get; set; }
    public DateTime ChangeDate { get; set; }
    public Guid CardId { get; set; }
    public Card Card { get; set; }
}