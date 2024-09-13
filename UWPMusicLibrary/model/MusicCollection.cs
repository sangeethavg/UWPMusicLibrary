using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.ContentRestrictions;
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
                if (file.Name.Contains("jpg"))
                {

                    StorageFile savedFile1 = await localFolder.GetFileAsync($"{file.DisplayName}.mp3");
                    if (savedFile1 != null)
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
                new Music("Death Grips - Beware", false),
                new Music("Death Grips - No Love", false),
                new Music("Sleepmakeswaves - It's Dark, It's Cold, It's Winter", false)
            };            
        }
    }
}
