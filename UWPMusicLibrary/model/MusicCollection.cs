using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPMusicLibrary.model
{
    public static class MusicCollection
    {
        public static void GetAllMusics(ObservableCollection<Music> musics)
        {
            var allMusics = getMusics();
            musics.Clear();
            allMusics.ForEach(music => musics.Add(music));
        }
        private static List<Music> getMusics() {
            return new List<Music>
            {
                new Music("A Bar Song"),
                new Music("Taste"),
                new Music("Please Pelase Please"),
                new Music("Espresso"),
                new Music("I Had some Help"),
                new Music("Die with a smile"),
                new Music("Birds of a feather"),
                new Music("Good Luck, Babe"),
                new Music("Not like Us"),
                new Music("Lose Control")
            };
            
        }
    }
}
