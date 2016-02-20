using Microsoft.Practices.Prism.Mvvm;
using WpfMusicPlayer.Model;

namespace WpfMusicPlayer.Views
{
    /// <summary>
    /// Interaction logic for MusicPlayerView.xaml
    /// </summary>
    public partial class MusicPlayerView : IView
    {
        public MusicPlayerView()
        {
            InitializeComponent();            
        }

        private void OnArtistSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var artist = ArtistListView.SelectedItem as Artist;
            if (artist != null)
            {
                AlbumListView.ItemsSource = artist.Albums;
                AlbumsNumber.Text = artist.Albums.Count.ToString();
                SongsNumber.Text = 0.ToString();
                SongListView.ItemsSource = null;
            }
        }

        private void OnAlbumSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var album = AlbumListView.SelectedItem as Album;
            if (album != null)
            {
                SongListView.ItemsSource = album.Songs;
                SongsNumber.Text = album.Songs.Count.ToString();            
            }
        }
    }
}
