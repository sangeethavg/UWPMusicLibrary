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
            //string ImagefolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Image");
            //string MusicfolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets\\Resources");

            //if (Directory.Exists(MusicfolderPath))
            //{
            //    string[] filePaths = Directory.GetFiles(MusicfolderPath);

            //    //new list for upload collection page
            //    foreach (string filePath in filePaths)
            //    {
            //        string content = File.ReadAllText(filePath);
            //        Console.WriteLine(content);
            //        // if music file with same name as image file is found in music folder
            //        if (File.Exists(filePath)) 
            //        {
            //            // then add to listOfMusic
            //            musics.Add(new Music("", true));
            //        }
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Directory not found.");
            //}


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
