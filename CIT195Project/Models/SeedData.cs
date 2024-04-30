using Microsoft.EntityFrameworkCore;
using CIT195Project.Data;

namespace CIT195Project.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HawksContext(
                serviceProvider.GetRequiredService<DbContextOptions<HawksContext>>()))
            {
                // Look for any hawks already in the database.
                if (context.Hawk.Any())
                {
                    return;   // DB has been seeded
                }

                context.Hawk.AddRange(
                    new Hawk { Name = "Red-tailed Hawk", LatinName = "Buteo jamaicensis", Wingspan = 4.7f, IsEndangered = false, Rarity = "Common" },
                    new Hawk { Name = "Sharp-shinned Hawk", LatinName = "Accipiter striatus", Wingspan = 2.3f, IsEndangered = false, Rarity = "Uncommon" },
                    new Hawk { Name = "Cooper’s Hawk", LatinName = "Accipiter cooperii", Wingspan = 3.0f, IsEndangered = false, Rarity = "Uncommon" },
                    new Hawk { Name = "Northern Goshawk", LatinName = "Accipiter gentilis", Wingspan = 3.3f, IsEndangered = false, Rarity = "Rare" },
                    new Hawk { Name = "Broad-winged Hawk", LatinName = "Buteo platypterus", Wingspan = 3.3f, IsEndangered = false, Rarity = "Common" },
                    new Hawk { Name = "Rough-legged Hawk", LatinName = "Buteo lagopus", Wingspan = 4.5f, IsEndangered = false, Rarity = "Rare" }
                );

                context.SaveChanges();
            }
        }
    }
}
