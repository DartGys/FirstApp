using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.BLL.Common.Mapping;
using TaskBoard.DAL.Data;
using TaskBoard.DAL.Data.Entities;

namespace TaskBoard.Tests;

internal static class UnitTestHelper
    {
        public static DbContextOptions<ApplicationDbContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        public static IMapper CreateMapperProfile()
        {
            var myProfile = new AssemblyMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }

        public static void SeedData(ApplicationDbContext context)
        {
            var boards = new List<Board>()
            {
                new Board() { Id = new Guid("3deb337b-ba6d-4050-a93c-7753aacd6d20"), Name = "Board3" },
                new Board() { Id = new Guid("210ab2be-b450-4909-bc04-69ff5a8b1a1f"), Name = "Board4" }
            };

            
            context.Boards.AddRange(boards);
            
            context.SaveChanges();
        }
    }