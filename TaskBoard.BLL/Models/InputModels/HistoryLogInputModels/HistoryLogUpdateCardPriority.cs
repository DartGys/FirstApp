using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogUpdateCardPriority : HistoryLogInputModel
{
    public HistoryLogUpdateCardPriority(Guid cardId) : base(cardId) { }

    public static string CardName { get; set; }
    public static string PreviousCardPriority { get; set; }
    public static string NewCardPriority { get; set; }
    public string ChangeDescription { get; private set; } =
        $"You changed the priority <strong>{CardName}</strong> from <strong>{PreviousCardPriority}</strong> to <strong>{NewCardPriority}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogUpdateCardPriority, HistoryLog>();
    }
}