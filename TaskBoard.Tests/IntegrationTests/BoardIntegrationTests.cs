using System.Text;
using Newtonsoft.Json;
using TaskBoard.BLL.Models.ViewModels.List;
using NUnit.Framework;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.DAL.Data;


namespace TaskBoard.Tests.IntegrationTests;

public class BoardIntegrationTests
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;
    private const string RequestUri = "api/board/";
    
    [SetUp]
    public void Init()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    
    [Test]
    public async Task BoardController_GetAll_ReturnsAllFromDb()
    {
        //arrange
        var expected = ExpectedBoardModels.ToList();

        // act
        var httpResponse = await _client.GetAsync(RequestUri);

        // assert
        httpResponse.EnsureSuccessStatusCode();
        var stringResponse = await httpResponse.Content.ReadAsStringAsync();
        var actual = JsonConvert.DeserializeObject<IEnumerable<BoardVm>>(stringResponse).ToList();

        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public async Task BoardController_Add_AddsBoardToDb()
    {
        //arrange
        var id = Guid.NewGuid();
        
        var board = new BoardInputModel()
        {
            Id = id.ToString(),
            Name = "NewBoard",
        };

        var content = new StringContent(JsonConvert.SerializeObject(board), Encoding.UTF8, "application/json");

        //act
        var httpResponse = await _client.PostAsync(RequestUri, content);

        //assert
        httpResponse.EnsureSuccessStatusCode();
        
        await CheckBoardInfoIntoDb(board, id, 3);
    }
    
    [Test]
    public async Task BoardController_Update_UpdateBoardInDb()
    {
        //arrange
        var id = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20");
        
        var board = new BoardInputModel()
        {
            Id = id.ToString(),
            Name = "UpdatedBoard",
        };

        var content = new StringContent(JsonConvert.SerializeObject(board), Encoding.UTF8, "application/json");

        //act
        var httpResponse = await _client.PatchAsync(RequestUri, content);

        //assert
        httpResponse.EnsureSuccessStatusCode();
        
        await CheckBoardInfoIntoDb(board, id, 2);
    }
    
    [Test]
    public async Task BoardsController_Delete_DeletesBoardFromDb()
    {
        // arrange
        var boardId = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20");
        var expectedLength = ExpectedBoardModels.Count() - 1;

        // act
        var httpResponse = await _client.DeleteAsync(RequestUri + boardId);

        // assert
        httpResponse.EnsureSuccessStatusCode();
        using (var test = _factory.Services.CreateScope())
        {
            var context = test.ServiceProvider.GetService<ApplicationDbContext>();
            context.Boards.Should().HaveCount(expectedLength);
        }
    }
    
    private async Task CheckBoardInfoIntoDb(BoardInputModel board, Guid boardId, int expectedLength)
    {
        using (var test = _factory.Services.CreateScope())
        {
            var context = test.ServiceProvider.GetService<ApplicationDbContext>();
            context.Boards.Should().HaveCount(expectedLength);
            
            var dbBoard = await context.Boards.FindAsync(boardId);
            dbBoard.Should().NotBeNull().And.BeEquivalentTo(board, options => options
                .Including(x => x.Name)
            );
        }
    }
    
    private static readonly IEnumerable<BoardVm> ExpectedBoardModels =
        new List<BoardVm>()
        {
            new BoardVm() { Id = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20"), Name = "Board3" },
            new BoardVm() { Id = new Guid("210ab2be-b450-4909-bc04-69ff5a8b1a1f"), Name = "Board4" }
        };
    
    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }
}