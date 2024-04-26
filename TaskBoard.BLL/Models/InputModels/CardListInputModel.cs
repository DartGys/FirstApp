using AutoMapper;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.BLL.Models.InputModels;

public class CardListInputModel : IMapWith<CardList>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CardListInputModel, CardList>();
    }
}