using Models;
using Proxy_API.DB;

namespace Proxy_API.Services
{
    public class ProjectUseCases(APIDataContext context) : IProjectUseCases
    {
        public IAsyncEnumerable<Projects> GetProjectsAsync()
        {
            return context.Projects.AsAsyncEnumerable();
        }
    }

    public interface IProjectUseCases
    {
        IAsyncEnumerable<Projects> GetProjectsAsync();
    }
}
