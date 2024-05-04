using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardList : HistoryLogInputModel
{
    public HistoryLogUpdateCardList() { }
    public HistoryLogUpdateCardList(Guid cardId, string cardName) : base(cardId, cardName) { }

    public string PreviousCardList { get; set; }
    public string NewCardList { get; set; }

    public string ChangeDescription => $"You moved <strong>{CardName}</strong> from <strong>{PreviousCardList}</strong> to strong>{NewCardList}</strong>";

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardList, HistoryLog>();
    }
}