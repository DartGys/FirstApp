using Moq;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Services;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.Tests.UnitTests;

public class CardListServiceTests
{
    [Test]
    public async Task CardListService_AddAsync_AddsModel()
    {
        //arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(m => m.CardList.AddAsync(It.IsAny<CardList>(), CancellationToken.None));

        var cardListService = new CardListService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile(), new HistoryLogService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile()));
        
        var cardList = new CardListInputModel()
        {
            Id = new Guid().ToString(),
            Name = "NewCardList"
        };

        //act
        await cardListService.AddAsync(cardList);

        //assert
        mockUnitOfWork.Verify(x => x.CardList.AddAsync(It.Is<CardList>(x => 
            x.Id == new Guid(cardList.Id)), CancellationToken.None), Times.Once);
        mockUnitOfWork.Verify(x => x.SaveChangeAsync(CancellationToken.None), Times.Once);
    }
}