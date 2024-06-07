using Models;
using Models.Interfaces;
using System.Net.Http.Json;

namespace Client
{
    internal class ProjectProxy(HttpClient client) : IProjectUseCases
    {
        private readonly string controller = typeof(Project).Name;

        public IAsyncEnumerable<Project> GetProjectsAsync()
        {
           
            return client.GetFromJsonAsAsyncEnumerable<Project>(BuildRequestUri(nameof(GetProjectsAsync)));
        }

        private string BuildRequestUri(string action)
        {
            return $"api/{controller}/{action}";
        }
    }
}
