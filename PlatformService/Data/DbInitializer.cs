using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context, bool isProduction)
    {
        SeedData(context, isProduction);
    }

    private static void SeedData(AppDbContext context, bool isProduction)
    {

        if (isProduction)
        {
            Console.WriteLine("Applying SQL DB Migrations");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to apply DB Migration - {ex.Message}");
            }
        }
        if (!context.Platforms.Any())
        {
            Console.WriteLine("Seeding Data");
            context.Platforms.AddRange(
            new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
            new Platform { Name = "AWS", Publisher = "Amazon", Cost = "Free" },
            new Platform { Name = "Angular", Publisher = "Google", Cost = "Free" },
             new Platform { Name = "Docker", Publisher = "Docker", Cost = "Free" },
            new Platform { Name = "React", Publisher = "Facebook", Cost = "Free" }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Data already present");
        }
    }
}