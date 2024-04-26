using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogDeleteCard : HistoryLogInputModel
{
    public HistoryLogDeleteCard() { }
    public HistoryLogDeleteCard(Guid cardId) : base(cardId) { }

    public string CardName { get; set; }
    public string CardList { get; set; }

    public string ChangeDescription => $"You deleted <strong>{CardName}</strong> from <strong>{CardList}</strong>";

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogDeleteCard, HistoryLog>();
    }
}