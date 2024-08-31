using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewMusicPage : Page
    {
        public AddNewMusicPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void uploadImage_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.ViewMode = PickerViewMode.Thumbnail;

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".gif");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                BitmapImage bitmapImage = new BitmapImage();
                using (var stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    await bitmapImage.SetSourceAsync(stream);
                }

                uploadedImage.Source = bitmapImage;
                StorageFolder localfolder = ApplicationData.Current.LocalFolder;
                StorageFile savedFile = await file.CopyAsync(localfolder, file.Name, NameCollisionOption.ReplaceExisting);
                var savedFilePath = savedFile.Path;
                Console.WriteLine("savedFilePath");
                Console.WriteLine(savedFilePath);
            }
            else
            {
                return;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var imageSource = uploadedImage.Source as BitmapImage;
            if (imageSource == null)

            {
                
                return;
            }

        }
            private async void uploadAudioFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.ViewMode = PickerViewMode.Thumbnail;

            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".wav");


            StorageFile file = await openPicker.PickSingleFileAsync();
        
            
            }
       
        private void Save_Click(object sender, RoutedEventArgs e)
        {

       


            var imageSource = uploadedImage.Source as BitmapImage;
                if (imageSource == null)
                {
                    
                    return;
                }

            
        }
    }
   
    
}