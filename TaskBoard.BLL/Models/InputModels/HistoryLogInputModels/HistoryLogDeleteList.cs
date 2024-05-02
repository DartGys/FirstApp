using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.HistoryLogInputModels;

public class HistoryLogDeleteList : IMapWith<HistoryLog>
{
    public string ListName { get; set; }
    public IEnumerable<string> CardNames { get; set; }
    public DateTime ChangeDate { get; private set; } = DateTime.UtcNow;

    public string ChangeDescription => $"You deleted <strong>{ListName}</strong> with cards: {(CardNames.Any() ? string.Join(", ", CardNames) : "No card")}";
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLogDeleteList, HistoryLog>();
    }
}