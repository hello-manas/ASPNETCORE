using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicListApp.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Composers { get; set; }
        public string Singers { get; set; }
        public string Lyricists { get; set; }

        public string Year { get; set; }

        public int Plays { get; set; }
        public int Likes { get; set; }
    }
}
