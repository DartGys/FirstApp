using Microsoft.Extensions.DependencyInjection;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.BLL.Interfaces.Services;
using TaskBoard.BLL.Services;

namespace TaskBoard.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AssemblyMappingProfile).Assembly); 

        services.AddScoped<ICardListService, CardListService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IPriorityService, PriorityService>();
        services.AddScoped<IHistoryLogService, HistoryLogService>();
        services.AddScoped<IBoardService, BoardService>();

        return services;
    }
}