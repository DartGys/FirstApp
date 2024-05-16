using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.DAL.Data;
using TaskBoard.DAL.Data.Repository;
using TaskBoard.DAL.Interfaces;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<ICardListRepository, CardListRepository>();
        services.AddScoped<IHistoryLogRepository, HistoryLogRepository>();
        services.AddScoped<IPriorityRepository, PriorityRepository>();
        services.AddScoped<IBoardRepository, BoardRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                
            })
        );
        
        return services;
    }
}