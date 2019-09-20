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
                        DrinkName = "PBR",
                        DrinkDescription = "Hipster beer",
                        Price = 2.00M
                    },
                    new BarMenu
                    {
                        DrinkName = "Yuenling",
                        DrinkDescription = "American Beer",
                        Price = 2.25M
                    },
                    new BarMenu
                    {
                        DrinkName = "Heineken",
                        DrinkDescription = "I have no idea how it tastes",
                        Price = 2.50M
                    },
                    new BarMenu
                    {
                        DrinkName = "Stella Artois",
                        DrinkDescription = "It's pretty good",
                        Price = 3.50M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
