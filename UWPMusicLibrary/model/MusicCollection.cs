using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPMusicLibrary.model
{
    public static class MusicCollection
    {
        public static void GetAllMusics(ObservableCollection<Music> musics)
        {
            var allMusics = getMusics();
            musics.Clear();
            allMusics.ForEach(music => musics.Add(music));
            getNewAddedMusics(musics);
        }
        private async static void getNewAddedMusics(ObservableCollection<Music> musics)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            IReadOnlyList<StorageFile> files = await localFolder.GetFilesAsync();

            // Add each file name to the ListView
            var addedMusic = new List<Music>();
            foreach (StorageFile file in files)
            {
               if ( file.Name.Contains("jpg"))
                {
                    
                    StorageFile savedFile1 = await localFolder.GetFileAsync($"{file.DisplayName}.mp3");
                    if ( savedFile1 != null )
                    {
                        Music music = new Music(file.DisplayName, true);
                        await music.LoadBitmapImage(music);
                        musics.Add(music);
                    }
                    
                }
            }
        }
           
        
        private static List<Music> getMusics() {
            return new List<Music>
            {
                new Music("A Bar Song", false),
                new Music("Taste", false),
                new Music("Please Pelase Please", false),
                new Music("Espresso", false),
                new Music("I Had some Help", false),
                new Music("Die with smile", false),
                new Music("Birds of a feather", false),
                new Music("Good Luck, Babe", false),
                new Music("Not like Us", false),
                new Music("Lose Control", false)
            };            
        }
    }
}
