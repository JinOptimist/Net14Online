using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.SeedData
{
    public static class LifeScoreSeedData
    {
        public static async Task AddDefaultTeams(WebDbContext db)
        {
            if (await db.Teams.AnyAsync())
            {
                return;
            }

            var teams = new List<Team>
            {
                new Team
                {
                    Name = "Minsk",
                    Liga = "BHL",
                    ShortName = "MN",
                    Country = "Belarus"
                },
                new Team
                {
                    Name = "Vitebsk",
                    Liga = "BHL",
                    ShortName = "VIT",
                    Country = "Belarus"
                },
                new Team
                {
                    Name = "Gomel",
                    Liga = "BHL",
                    ShortName = "GOM",
                    Country = "Belarus"
                },
                new Team
                {
                    Name = "Mogilev",
                    Liga = "BHL",
                    ShortName = "MOG",
                    Country = "Belarus"
                },
            };

            db.Teams.AddRange(teams);
            await db.SaveChangesAsync();
        }

        public static async Task AddDefaultSportGames(WebDbContext db)
        {
            if (await db.SportGames.AnyAsync())
            {
                return;
            }

            var sportGames = new List<SportGame>
            {
                new SportGame
                {
                    Date = new DateTime(2024,01,08),
                    Team1Id = 1,
                    Team2Id = 2,
                    Team1Goals = 1,
                    Team2Goals = 2,
                    TeamIDWin = 2
                },
                new SportGame
                {
                    Date = new DateTime(2024,02,02),
                    Team1Id = 1,
                    Team2Id = 2,
                },
                new SportGame
                {
                    Date = new DateTime(2024,01,25),
                    Team1Id = 3,
                    Team2Id = 2,
                },
                new SportGame
                {
                    Date = new DateTime(20243,12,28),
                    Team1Id = 3,
                    Team2Id = 2,
                    Team1Goals = 3,
                    Team2Goals = 7,
                    TeamIDWin = 2
                }
            };

            db.SportGames.AddRange(sportGames);
            await db.SaveChangesAsync();
        }
    }
}
