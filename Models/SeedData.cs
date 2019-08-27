using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bar.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BarContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BarContext>>()))
            {
                // Look for specific drink
                if (context.BarMenu.Any())
                {
                    return;   // DB has been seeded
                }

                context.BarMenu.AddRange(
                    new BarMenu
                    {
                        DrinkName = "Natural Light",
                        DrinkDescription = "It's pretty gross.",
                        Price = 2.00M
                    },

                  new BarMenu
                  {
                      DrinkName = "Yuengling",
                      DrinkDescription = "Creamy taste with tones of chocolate.",
                      Price = 3.00M
                  }
                );
                context.SaveChanges();
            }
        }
    }
}
