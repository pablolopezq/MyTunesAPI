using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Core.Entities
{
    public class Album : BaseEntity
    {
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
