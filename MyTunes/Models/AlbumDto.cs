using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTunes.Models
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Artist { get; set; }

        public int Price { get; set; }

        public string Genre { get; set; }

        public int Rating { get; set; }

        public string Date { get; set; }

        public string Description { get; set; }

        public string Img { get; set; }
    }
}
