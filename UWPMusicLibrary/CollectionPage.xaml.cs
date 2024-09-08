using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPMusicLibrary.model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionPage : Page
    {
        public ObservableCollection<Music> musics;

        public CollectionPage()
        {
            this.InitializeComponent();
            musics = new ObservableCollection<Music>();
            MusicCollection.GetAllMusics(musics);

        }

        private void MusicCollectionListView_ItemClick(object sender, ItemClickEventArgs e)
        { }
        

        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void PauseMusic_Click(object sender, RoutedEventArgs e)
        {
            if (MusicPlayer.CanPause)
            {
                MusicPlayer.Pause();
            }
        }

        private void StopMusic_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Stop();
        }

        private void PlayMusic_Click(object sender, RoutedEventArgs e)
        {
            Music selectedMusic = (Music)MusicCollectionListView.SelectedItem;
            if (selectedMusic != null && selectedMusic.IsNew == false) {
                MusicPlayer.Source = new Uri(this.BaseUri, selectedMusic.AudioFile);// Adjust path as needed
                MusicPlayer.Play();
            }
            else if (selectedMusic != null && selectedMusic.IsNew == true)
            {
                PlayAudioFromAppData(selectedMusic.AudioFile);
            }
           
        }
        private async void PlayAudioFromAppData(string fileName)
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile audioFile = await localFolder.GetFileAsync(fileName);
                MusicPlayer.SetSource(await audioFile.OpenAsync(FileAccessMode.Read), audioFile.ContentType);
                MusicPlayer.Play();
            }
            catch (Exception ex)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Unable to play the audio file: " + ex.Message,
                    CloseButtonText = "OK"
                };
                await errorDialog.ShowAsync();
            }
        }
    }


    }
