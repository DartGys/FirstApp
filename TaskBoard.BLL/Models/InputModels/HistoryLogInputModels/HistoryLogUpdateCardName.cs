using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardName : HistoryLogInputModel
{
    public HistoryLogUpdateCardName() { }
    public HistoryLogUpdateCardName(Guid cardId, string cardName) : base(cardId, cardName) { }

    public string PreviousCardName { get; set; }
    public string ChangeDescription => $"You renamed <strong>{PreviousCardName}</strong> to <strong>{CardName}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardName, HistoryLog>();
    }
}