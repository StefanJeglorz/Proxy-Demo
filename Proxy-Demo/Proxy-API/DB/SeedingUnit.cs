using Models;

namespace Proxy_API.DB
{
    public class SeedingUnit(APIDataContext context) : ISeedingUnit
    {
        public async Task SeedData()
        {
            var projects = new List<Project>();
            for (int i = 0; i < 100000; i++)
            {
                projects.Add(new Project()
                {
                    Budget = Random.Shared.Next(1000, 1000000),
                    Code = Guid.NewGuid().ToString(),
                    From = DateTime.Now.AddDays(Random.Shared.Next(-100, 100)),
                    Until = DateTime.Now.AddDays(Random.Shared.Next(100, 200)),
                    Name = $"Project {i}"
                });
            }

            await context.Projects.AddRangeAsync(projects);
            await context.SaveChangesAsync();
        }
    }

    public interface ISeedingUnit
    {
        Task SeedData();
    }
}
