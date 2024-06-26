using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.DAL.Data;

namespace TaskBoard.Tests.IntegrationTests;

internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            RemoveLibraryDbContextRegistration(services);

            var serviceProvider = GetInMemoryServiceProvider();

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.Empty.ToString());
                options.UseInternalServiceProvider(serviceProvider);
            });

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                UnitTestHelper.SeedData(context);
            }
        });
    }

    private static ServiceProvider GetInMemoryServiceProvider()
    {
        return new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();
    }

    private static void RemoveLibraryDbContextRegistration(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(
            d => d.ServiceType ==
                 typeof(DbContextOptions<ApplicationDbContext>));

        if (descriptor != null)
        {
            services.Remove(descriptor);
        }
    }
}