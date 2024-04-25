using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardName : HistoryLogInputModel
{
    public HistoryLogUpdateCardName(Guid cardId) : base(cardId) { }

    public static string PreviousCardName { get; set; }
    public static string NewCardName { get; set; }
    public string ChangeDescription { get; private set; } =
        $"You renamed <strong>{PreviousCardName}</strong> to <strong>{NewCardName}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardName, HistoryLog>();
    }
}