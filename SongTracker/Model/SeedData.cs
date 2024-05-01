using Microsoft.EntityFrameworkCore;
using SongTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace SongTracker.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SongTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SongTrackerContext>>()))
            {
                if (context == null || context.Songs == null)
                {
                    throw new ArgumentNullException("Null SongTrackerContext");
                }

                // Look for any movies.
                if (context.Songs.Any())
                {
                    return;   // DB has been seeded
                }

                context.Songs.AddRange(
                    new Song
                    {
                        Title = "Shine On You Crazy Diamond (Pts.1-5)",
                        Album = "Wish You Were Here",
                        Artist = "Pink Floyd",
                        Length = 13.31f,
                        ReleaseDate = DateTime.Parse("1975-09-12")                    },

                    new Song
                    {
                        Title = "Mountains",
                        Album = "Interstellar (Original Motion Picture Soundtrack)",
                        Artist = "Hans Zimmer",
                        Length = 3.39f,
                        ReleaseDate = DateTime.Parse("2014-11-18")
                    },

                    new Song
                    {
                        Title = "Epitaph",
                        Album = "In The Court Of The Crimson King",
                        Artist = "King Crimson",
                        Length = 8.45f,
                        ReleaseDate = DateTime.Parse("1969-10-10")
                    },

                    new Song
                    {
                        Title = "Marbled",
                        Album = "Marbled",
                        Artist = "Abhi The Nomad",
                        Length = 4.03f,
                        ReleaseDate = DateTime.Parse("2018-2-09")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
