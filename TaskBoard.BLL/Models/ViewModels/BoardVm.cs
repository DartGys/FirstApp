using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.ViewModels.List;

public class BoardVm : IMapWith<Board>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Board, BoardVm>();
    }
}