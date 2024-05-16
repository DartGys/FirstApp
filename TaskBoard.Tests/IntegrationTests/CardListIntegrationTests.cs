using System.Text;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TaskBoard.BLL.Models.InputModels;
using TaskBoard.DAL.Data;

namespace TaskBoard.Tests.IntegrationTests;

public class CardListIntegrationTests
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;
    private const string RequestUri = "api/cardlist/";
    
    [SetUp]
    public void Init()
    {
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    
    [Test]
    public async Task CardListController_Add_AddsCardListToDb()
    {
        //arrange
        var id = Guid.NewGuid();
        
        var cardList = new CardListInputModel()
        {
            Id = id.ToString(),
            Name = "NewCardList",
        };

        var content = new StringContent(JsonConvert.SerializeObject(cardList), Encoding.UTF8, "application/json");

        //act
        var httpResponse = await _client.PostAsync(RequestUri, content);

        //assert
        httpResponse.EnsureSuccessStatusCode();
        
        await CheckBoardInfoIntoDb(cardList, id, 1);
    }
    
    private async Task CheckBoardInfoIntoDb(CardListInputModel cardList, Guid cardListId, int expectedLength)
    {
        using (var test = _factory.Services.CreateScope())
        {
            var context = test.ServiceProvider.GetService<ApplicationDbContext>();
            context.CardLists.Should().HaveCount(expectedLength);
            
            var dbBoard = await context.CardLists.FindAsync(cardListId);
            dbBoard.Should().NotBeNull().And.BeEquivalentTo(cardList, options => options
                .Including(x => x.Name)
            );
        }
    }
    
    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }
}