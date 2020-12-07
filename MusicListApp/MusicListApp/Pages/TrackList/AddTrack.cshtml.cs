using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicListApp.Models;

namespace MusicListApp.Pages.TrackList
{
    public class AddTrackModel : PageModel
    {
        private readonly ApplicationDbContext _Db;

        public AddTrackModel(ApplicationDbContext appdbcontext)
        {
            this._Db = appdbcontext;
        }

        [BindProperty]
        public Track Track { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _Db.Tracks.AddAsync(Track);
                await _Db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
