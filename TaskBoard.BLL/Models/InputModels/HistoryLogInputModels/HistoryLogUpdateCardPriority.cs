using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardPriority : HistoryLogInputModel
{
    public HistoryLogUpdateCardPriority() { }
    public HistoryLogUpdateCardPriority(Guid cardId, string cardName) : base(cardId, cardName) { }

    public string PreviousCardPriority { get; set; }
    public string NewCardPriority { get; set; }
    public string ChangeDescription => $"You changed the priority <strong>{CardName}</strong> from <strong>{PreviousCardPriority}</strong> to <strong>{NewCardPriority}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardPriority, HistoryLog>();
    }
}