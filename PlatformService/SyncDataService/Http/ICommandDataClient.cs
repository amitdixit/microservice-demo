using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(PlatformReadDto platform);
}

public class CommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(platform), Encoding.UTF8, "application/json");
        // "https://localhost:7190/api/cs/platforms"
        System.Console.WriteLine($"{_configuration["CommandService"]}platforms");

        var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}platforms", httpContent);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Sync POST to Command Service returned OK");
        }
        else
        {
            Console.WriteLine("Sync POST to Command Service returned FAILED");
        }
    }
}