using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HamtruyenLibrary.Models
{
    public class Playlist : IObject
    {
        public Playlist()
        {
        }
        public string PlayListName { get; set; }
        public string PlayListArtist { get; set; }
        public string PlayListImage { get; set; }
        public string MenuID { get; set; }
    }
}
