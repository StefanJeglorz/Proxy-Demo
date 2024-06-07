namespace Models.Interfaces
{
    public interface IProjectUseCases
    {
        IAsyncEnumerable<Projects> GetProjectsAsync();
    }
}
