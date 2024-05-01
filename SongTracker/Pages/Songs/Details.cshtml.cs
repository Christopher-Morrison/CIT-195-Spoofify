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
    public class DetailsModel : PageModel
    {
        private readonly SongTracker.Data.SongTrackerContext _context;

        public DetailsModel(SongTracker.Data.SongTrackerContext context)
        {
            _context = context;
        }

        public Song Songs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FirstOrDefaultAsync(m => m.Id == id);
            if (songs == null)
            {
                return NotFound();
            }
            else
            {
                Songs = songs;
            }
            return Page();
        }
    }
}
