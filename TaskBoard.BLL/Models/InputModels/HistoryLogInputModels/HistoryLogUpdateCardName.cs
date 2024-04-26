using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardName : HistoryLogInputModel
{
    public HistoryLogUpdateCardName() { }
    public HistoryLogUpdateCardName(Guid cardId) : base(cardId) { }

    public string PreviousCardName { get; set; }
    public string NewCardName { get; set; }
    public string ChangeDescription => $"You renamed <strong>{PreviousCardName}</strong> to <strong>{NewCardName}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardName, HistoryLog>();
    }
}