using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MatchHistory.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MatchHistoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<MatchHistoryContext>>()))
            {
                // Look for any exisiting match histories.
                if (context.MatchHistoryItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.MatchHistoryItem.AddRange(
                    new MatchHistoryItem
                    {
                        Date = "YYYY/MM/DD",
                        Location = "Cue City",
                        Game = "8 Ball",
                        Home = "Opponent 1",
                        Opposition = "Opponent 2",
                        Winner = "Opponent 1",
                        Comment = "N/A"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
