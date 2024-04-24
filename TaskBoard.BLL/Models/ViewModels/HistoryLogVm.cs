using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.ViewModels.List;

public class HistoryLogVm
{
    public string ChangeDescription { get; set; }
    public DateTime ChangeDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HistoryLog, HistoryLogVm>();
    }
}