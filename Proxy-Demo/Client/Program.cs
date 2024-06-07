using Client;
using Models.Interfaces;
Console.WriteLine("Proxy Pattern \n");
Console.WriteLine("Loading Project from API \n");

IProjectUseCases projectUseCases = new ProjectProxy(new HttpClient() { BaseAddress = new Uri("https://localhost:7230") });

var tryCatch = new TryCatchProxy();
await tryCatch.Try(async () =>
{
    await foreach (var useCase in projectUseCases.GetProjectsAsync())
    {
        Console.WriteLine(useCase.Name);
    }
});

Console.ReadLine();