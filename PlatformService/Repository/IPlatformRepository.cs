using PlatformService.Models;

namespace PlatformService.Repository;

public interface IPlatformRepository
{
    bool SaveChanges();
    IEnumerable<Platform> GetAllPlatforms();

    Platform GetPlatformById(int platformId);
    void CreatePlatform(Platform platform);

}