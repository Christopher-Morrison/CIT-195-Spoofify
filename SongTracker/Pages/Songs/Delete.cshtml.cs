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
    public class DeleteModel : PageModel
    {
        private readonly SongTracker.Data.SongTrackerContext _context;

        public DeleteModel(SongTracker.Data.SongTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs != null)
            {
                Songs = songs;
                _context.Songs.Remove(Songs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
