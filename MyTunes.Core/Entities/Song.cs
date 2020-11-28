using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Core.Entities
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }

        public string Artist { get; set; }

        public int Price { get; set; }

        public int Duration { get; set; }

        public int Rating { get; set; }

        public int AlbumId { get; set; }
    }
}
