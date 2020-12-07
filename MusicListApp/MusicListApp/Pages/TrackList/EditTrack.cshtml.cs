using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicListApp.Models;

namespace MusicListApp.Pages.TrackList
{
    public class EditTrackModel : PageModel
    {
        private readonly ApplicationDbContext _Db;

        public EditTrackModel(ApplicationDbContext appdbcontext)
        {
            this._Db = appdbcontext;
        }

        [BindProperty]
        public Track Track { get; set; }
        public async Task OnGet(int id)
        {
            Track = await _Db.Tracks.FindAsync(id);
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var MyTrack = await _Db.Tracks.FindAsync(Track.ID);
                MyTrack.Name = Track.Name;
                MyTrack.Composers = Track.Composers;
                MyTrack.Singers = Track.Singers;
                MyTrack.Lyricists = Track.Lyricists;
                MyTrack.Year = Track.Year;

                await _Db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
             
        }
    }
}
