using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.ViewModels.List;

public class CardListVm : IMapWith<CardList>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyList<CardVmList> Cards { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CardList, CardListVm>();
    }
}