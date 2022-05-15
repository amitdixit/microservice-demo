using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Repository;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CreatePlatform(Platform platform)
    {
        if (platform is null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        _context.Platforms.Add(platform);
        SaveChanges();
    }

    public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

    public Platform GetPlatformById(int platformId) => _context.Platforms.FirstOrDefault(p => p.Id == platformId);

    public bool SaveChanges() => (_context.SaveChanges() >= 0);
}