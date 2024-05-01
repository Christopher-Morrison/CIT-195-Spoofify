using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SongTracker.Data;
using SongTracker.Model;

namespace SongTracker.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly SongTracker.Data.SongTrackerContext _context;

        public IndexModel(SongTracker.Data.SongTrackerContext context)
        {
            _context = context;
        }

        public IList<Song> Songs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Songs = await _context.Songs.ToListAsync();
        }
    }
}
