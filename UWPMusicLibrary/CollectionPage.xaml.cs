using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPMusicLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionPage : Page
    {
        public CollectionPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
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
            MusicPlayer.Source = new Uri("pack://application:,,,/Resources/YourAudioFile.mp3", UriKind.Absolute);// Adjust path as needed
            MusicPlayer.Play();
        }
    }


}
