using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogAddCard
{
    public Guid CardId { get; set; }
    public static string CardName { get; set; }
    public static string ListName { get; set; }

    public string ChangeDescription { get; private set; } =
        $"You added <strong>{CardName}</strong> to <strong>{ListName}</strong>";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogAddCard, HistoryLog>();
    }
}