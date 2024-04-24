using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogDeleteCard : HistoryLogInputModel
{
    public HistoryLogDeleteCard(Guid cardId) : base(cardId) { }

    public static string CardName { get; set; }
    public static string CardList { get; set; }
    
    public string ChangeDescription { get; private set; } =
        $"You deleted <strong>{CardName}</strong> from <strong>{CardList}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogDeleteCard, HistoryLog>();
    }
}