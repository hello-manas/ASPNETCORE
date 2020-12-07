using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicListApp.Models;

namespace MusicListApp.Pages.TrackList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext appdbcontext)
        {
            this._db = appdbcontext;
        }
        public IEnumerable<Track> Tracks { get; set; }
        public async Task OnGet()
        {
            Tracks = await _db.Tracks.ToListAsync();
        }

        public async Task<IActionResult> OnPostLike(int id)
        {
            var MyTrack = await _db.Tracks.FindAsync(id);
            MyTrack.Likes++;
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var MyTrack = await _db.Tracks.FindAsync(id);
            if (MyTrack == null)
            {
                return NotFound();

            }
            else
            {
                _db.Tracks.Remove(MyTrack);
                await _db.SaveChangesAsync();
                return RedirectToPage();
            }
        }
        [BindProperty]
        public string singer { get; set; }
        [BindProperty]
        public string composer { get; set; }
        [BindProperty]
        public string lyricist { get; set; }
        [BindProperty]
        public string year { get; set; }
        public async Task OnPostFilter()
        {
            singer = singer != null ? singer : "";
            composer = composer != null ? composer : "";
            lyricist = lyricist != null ? lyricist : "";
            year = year != null ? year : "";
            Tracks = await _db.Tracks.Where(x => x.Singers.Contains(singer)).ToListAsync();
            
        }

    }
}
