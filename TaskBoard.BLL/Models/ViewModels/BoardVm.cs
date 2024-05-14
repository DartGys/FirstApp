using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.ViewModels.List;

public class BoardVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Board, BoardVm>();
    }
}