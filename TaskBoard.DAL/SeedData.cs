using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.DAL.Data;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.DAL;

public static class SeedData
{
    public static IApplicationBuilder SeedDbData(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            Initialize(context);
        }
        catch (Exception ex)
        {

        }

        return app;
    }
    
    public static void Initialize(ApplicationDbContext context)
    {
        var boards = new List<Board>()
        {
            new Board() { Id = Guid.NewGuid(), Name = "Board1" },
            new Board() { Id = Guid.NewGuid(), Name = "Board2" }
        };
            
        var priorities = new List<Priority>()
        {
            new Priority { Id = Guid.NewGuid(), Name = "Low" },
            new Priority { Id = Guid.NewGuid(), Name = "Standart" },
            new Priority { Id = Guid.NewGuid(), Name = "High" }
        };

        var cardLists = new List<CardList>()
        {
            new CardList() { Id = Guid.NewGuid(), Name = "List1", BoardId = boards[0].Id },
            new CardList() { Id = Guid.NewGuid(), Name = "List2", BoardId = boards[1].Id }
        };

        var cards = new List<Card>()
        {
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card1", Description = "Description1", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[0].Id, CardListId = cardLists[0].Id, BoardId = cardLists[0].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card2", Description = "Description2", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[1].Id, CardListId = cardLists[0].Id, BoardId = cardLists[0].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card3", Description = "Description3", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[2].Id, CardListId = cardLists[0].Id, BoardId = cardLists[0].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card4", Description = "Description4", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[0].Id, CardListId = cardLists[0].Id, BoardId = cardLists[0].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card5", Description = "Description5", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[1].Id, CardListId = cardLists[0].Id, BoardId = cardLists[0].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card6", Description = "Description6", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[2].Id, CardListId = cardLists[1].Id, BoardId = cardLists[1].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card7", Description = "Description7", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[0].Id, CardListId = cardLists[1].Id, BoardId = cardLists[1].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card8", Description = "Description8", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[1].Id, CardListId = cardLists[1].Id, BoardId = cardLists[1].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card9", Description = "Description9", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[2].Id, CardListId = cardLists[1].Id, BoardId = cardLists[1].BoardId
            },
            new Card()
            {
                Id = Guid.NewGuid(), Name = "Card10", Description = "Description10", CreatedDate = DateTime.UtcNow,
                DueDate = RandomDate(), PriorityId = priorities[0].Id, CardListId = cardLists[1].Id, BoardId = cardLists[1].BoardId
            },
        };

        bool saveChange = false;
        
        if (!context.Priorities.Any())
        {
            context.Priorities.AddRange(priorities);
            saveChange = true;
        }

        if (!context.Boards.Any() && !context.CardLists.Any() && !context.Cards.Any() && !context.HistoryLogs.Any())
        {
            context.Boards.AddRange(boards);
            context.CardLists.AddRange(cardLists);
            context.Cards.AddRange(cards);
            context.HistoryLogs.AddRange(CreateLogList(cards, cardLists));

            saveChange = true;
        }

        if (saveChange)
        {
            context.SaveChanges();
        }
    }

    private static IEnumerable<HistoryLog> CreateLogList(List<Card> cards, List<CardList> cardLists)
    {
        foreach (var card in cards)
        {
            var historyLog = new HistoryLog()
            {
                Id = Guid.NewGuid(), CardId = card.Id, ChangeDate = DateTime.UtcNow, BoardId = card.BoardId,
                ChangeDescription = 
                    $"You added <strong>{card.Name}</strong> to <strong>{cardLists.First(x => x.Id == card.CardListId).Name}</strong>"
            };

            yield return historyLog;
        }
    }

    private static DateTime RandomDate()
    {
        Random rnd = new Random();

        DateTime now = DateTime.UtcNow;

        int maxDays = 30; 
        
        int randomDays = rnd.Next(maxDays);

        int randomHours = rnd.Next(24);
        int randomMinutes = rnd.Next(60);
        int randomSeconds = rnd.Next(60);

        DateTime randomDateTime = now.AddDays(randomDays)
            .AddHours(randomHours)
            .AddMinutes(randomMinutes)
            .AddSeconds(randomSeconds);

        return randomDateTime;
    }
}