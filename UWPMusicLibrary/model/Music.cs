using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMusicLibrary.model
{
    public class Music
    {
        public String Name {  get; set; }
        public String AudioFile { get; set; }
        public string ImageFile { get; set; }

        public Music(string name)
        {
            Name = name;
            AudioFile = $"/Assets/Resources/{Name}.mp3";
            ImageFile = $"/Assets/Image/{Name}.png";
        }
    }
}
