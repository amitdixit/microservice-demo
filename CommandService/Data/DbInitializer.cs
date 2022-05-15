using CommandService.Models;
using CommandService.Repository;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Data;

public class DbInitializer
{
    public static void Initialize(IPlatformDataClient grpcClient, ICommandRepository repository)
    {

        var platforms = grpcClient.ReturnAllPlatforms();

        SeedData(repository, platforms);
    }

    private static void SeedData(ICommandRepository repository, IEnumerable<Platform> platforms)
    {
        Console.WriteLine("Seeding new platforms...");

        foreach (var platform in platforms)
        {
            if (!repository.ExternalPlatformExists(platform.ExternalId))
            {
                repository.CreatePlatform(platform);
            }
            repository.SaveChanges();
        }
    }
}