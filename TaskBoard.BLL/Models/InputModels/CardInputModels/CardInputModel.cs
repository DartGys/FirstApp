using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.InputModels;

public class CardInputModel : IMapWith<Card>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public Guid PriorityId { get; set; }
    public Guid CardListId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CardInputModel, Card>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.Empty : new Guid(src.Id)));
    }
}