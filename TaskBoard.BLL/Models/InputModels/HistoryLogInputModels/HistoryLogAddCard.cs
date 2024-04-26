using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogAddCard : HistoryLogInputModel
{
    public HistoryLogAddCard() { }

    public HistoryLogAddCard(Guid cardId) : base(cardId) { }
    public string CardName { get; set; }
    public string ListName { get; set; }

    public string ChangeDescription => $"You added <strong>{CardName}</strong> to <strong>{ListName}</strong>";

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogAddCard, HistoryLog>();
    }
}