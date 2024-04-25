using AutoMapper;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.InputModels;

public class CardUpdateModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Guid PriorityId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CardUpdateModel, Card>();
    }
}