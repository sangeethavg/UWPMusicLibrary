using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPMusicLibrary.model
{
    public class Music
    {
        public String Name { get; set; }
        public String AudioFile { get; set; }
        public string ImageFile { get; set; }
        public bool IsNew = false;
        public BitmapImage imageSource { get; set; }
        public Music(string name, bool isNew)
        {
            Name = name;
            AudioFile = isNew ? $"{name}.mp3" : $"/Assets/Resources/{Name}.mp3";
            ImageFile = isNew ? $"{name}.jpg" : $"/Assets/Image/{Name}.jpg";
            imageSource = new BitmapImage(new Uri($"ms-appx:///Assets/Image/{Name}.jpg"));
            IsNew = isNew;
        }
        public async Task LoadBitmapImage(Music music)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile savedFile1 = await localFolder.GetFileAsync(music.ImageFile);

            if (savedFile1 != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (var stream = await savedFile1.OpenAsync(FileAccessMode.Read))
                {
                    await bitmapImage.SetSourceAsync(stream);
                }
                music.imageSource = bitmapImage;
            }

        }
    }
}
