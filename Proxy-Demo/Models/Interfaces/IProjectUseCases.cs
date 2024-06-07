namespace Models.Interfaces
{
    public interface IProjectUseCases
    {
        IAsyncEnumerable<Project> GetProjectsAsync();
    }
}
