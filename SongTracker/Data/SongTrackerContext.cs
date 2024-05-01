using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongTracker.Model;

namespace SongTracker.Data
{
    public class SongTrackerContext : DbContext
    {
        public SongTrackerContext (DbContextOptions<SongTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<SongTracker.Model.Song> Songs { get; set; } = default!;
    }
}
