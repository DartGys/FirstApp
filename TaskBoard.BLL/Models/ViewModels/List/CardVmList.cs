using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.BLL.Models.ViewModels.Details;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.ViewModels.List;

public class CardVmList : IMapWith<Card>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string PriorityName { get; set; }
    public Guid CardListId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Card, CardVmList>()
            .ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.Priority.Name));
    }
}