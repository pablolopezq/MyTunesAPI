using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTunes.Models
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Artist { get; set; }

        public int Price { get; set; }

        public int Duration { get; set; }

        public int Rating { get; set; }

        public int AlbumId { get; set; }
    }
}
