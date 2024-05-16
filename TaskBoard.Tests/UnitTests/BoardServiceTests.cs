using FluentAssertions;
using Moq;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.BLL.Models.ViewModels.List;
using TaskBoard.BLL.Services;
using TaskBoard.DAL.Data.Entities;
using TaskBoard.DAL.Interfaces;

namespace TaskBoard.Tests.UnitTests;

public class BoardServiceTests
{
    [Test]
    public async Task BoardService_GetAll_ReturnsAllBoards()
    {
        //arrange
        var expected = GetTestBoardModels;
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork
            .Setup(x => x.Board.GetAllAsync(CancellationToken.None))
            .ReturnsAsync(GetTestBoardEntities.AsEnumerable());

        var boardService = new BoardService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

        //act
        var actual = await boardService.GetAsync();

        //assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public async Task BoardService_AddAsync_AddsModel()
    {
        //arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(m => m.Board.AddAsync(It.IsAny<Board>(), CancellationToken.None));

        var boardService = new BoardService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
        var board = new BoardInputModel()
        {
            Id = GetTestBoardModels.First().Id.ToString(),
            Name = GetTestBoardModels.First().Name
        };

        //act
        await boardService.AddAsync(board);

        //assert
        mockUnitOfWork.Verify(x => x.Board.AddAsync(It.Is<Board>(x => 
            x.Id == new Guid(board.Id)), CancellationToken.None), Times.Once);
        mockUnitOfWork.Verify(x => x.SaveChangeAsync(CancellationToken.None), Times.Once);
    }
    
    [Test]
    public async Task BoardService_UpdateAsync_UpdatesBoard()
    {
        //arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(m => m.Board.Update(It.IsAny<Board>()));

        var boardService = new BoardService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());
        var board = new BoardInputModel()
        {
            Id = GetTestBoardModels.First().Id.ToString(),
            Name = GetTestBoardModels.First().Name
        };

        //act
        await boardService.UpdateAsync(board);

        //assert
        mockUnitOfWork.Verify(x => x.Board.Update(It.Is<Board>(x => 
            x.Id == new Guid(board.Id))), Times.Once);
        mockUnitOfWork.Verify(x => x.SaveChangeAsync(CancellationToken.None), Times.Once);
    }
    
    [Test]
    public async Task BoardService_DeleteAsync_DeleteBoard()
    {
        //arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(m => m.Board.Remove(It.IsAny<Board>()));

        var boardService = new BoardService(mockUnitOfWork.Object, UnitTestHelper.CreateMapperProfile());

        var boardId = Guid.NewGuid();

        //act
        await boardService.DeleteAsync(boardId);

        //assert
        mockUnitOfWork.Verify(x => x.Board.Remove(It.Is<Board>(x => 
            x.Id == boardId)), Times.Once);
        mockUnitOfWork.Verify(x => x.SaveChangeAsync(CancellationToken.None), Times.Once);
    }
    
    private static readonly IEnumerable<BoardVm> GetTestBoardModels =
        new List<BoardVm>()
        {
            new BoardVm() { Id = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20"), Name = "Board3" },
            new BoardVm() { Id = new Guid("210ab2be-b450-4909-bc04-69ff5a8b1a1f"), Name = "Board4" }
        };
    
    private static readonly IEnumerable<Board> GetTestBoardEntities =
        new List<Board>()
        {
            new Board() { Id = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20"), Name = "Board3" },
            new Board() { Id = new Guid("210ab2be-b450-4909-bc04-69ff5a8b1a1f"), Name = "Board4" }
        };
}