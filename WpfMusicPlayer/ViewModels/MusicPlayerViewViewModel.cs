using Prism.Mvvm;
using WpfMusicPlayer.Model;
using WpfMusicPlayer.Repository;
using System.Collections.ObjectModel;

namespace WpfMusicPlayer.ViewModels
{
    public class MusicPlayerViewViewModel : BindableBase
    {
        public MusicPlayerViewViewModel()
        {
            LoadMusicPlayerData();         
        }

        private async void LoadMusicPlayerDataAsync()
        {
            MusicDataRepository repository = new MusicDataRepository();
            MusicPlayerData musicPlayerData = await repository.LoadMusicDataModelAsync();
            if (musicPlayerData != null)
            {
                Artists = musicPlayerData.Artists;
                SetInitialSelections();
            }
        }

        private void LoadMusicPlayerData()
        {
            MusicDataRepository repository = new MusicDataRepository();
            MusicPlayerData musicPlayerData = repository.LoadMusicDataModel();
            if (musicPlayerData != null)
            {
                Artists = musicPlayerData.Artists;
                SetInitialSelections();
            }
        }

        private void SetInitialSelections()
        {
            NumberOfArtists = Artists.Count;
            if (Artists.Count > 0)
            {
                SelectedArtist = Artists[0];
                NumberOfAlbums = SelectedArtist.Albums.Count;
                if (NumberOfAlbums > 0)
                {
                    SelectedAlbum = SelectedArtist.Albums[0];
                    NumberOfSongs = SelectedAlbum.Songs.Count;
                    if (NumberOfSongs > 0)
                    {
                        SelectedSong = SelectedAlbum.Songs[0];
                    }
                }
            }
        }

        private ObservableCollection<Artist> artists = new ObservableCollection<Artist>();        
        public ObservableCollection<Artist> Artists
        {
            get
            {
                return artists;
            }   
            set
            {
                artists = value;
            }         
        }

        private int numberOfArtists = 0;
        public int NumberOfArtists
        {
            get
            {
                return numberOfArtists;
            }
            set
            {
                numberOfArtists = value;
            }
        }

        private Artist selectedArtist = null;
        public Artist SelectedArtist
        {
            get
            {
                return selectedArtist;
            }
            set
            {
                selectedArtist = value;
            }
        }

        private ObservableCollection<Album> albumsForArtist = new ObservableCollection<Album>();
        public ObservableCollection<Album> AlbumsForArtist
        {
            get
            {
                albumsForArtist = SelectedArtist.Albums;
                if (albumsForArtist.Count > 0)
                {
                    SelectedAlbum = albumsForArtist[0];
                }
                return albumsForArtist;
            }
        }

        private int numberOfAlbums = 0;
        public int NumberOfAlbums
        {
            get
            {
                return numberOfAlbums;
            }
            set
            {
                numberOfAlbums = value;
            }
        }

        private Album selectedAlbum = null;        
        public Album SelectedAlbum
        {
            get
            {
                return selectedAlbum;
            }
            set
            {
                selectedAlbum = value;
            }
        }

        private ObservableCollection<Song> songsForAlbum = new ObservableCollection<Song>();
        public ObservableCollection<Song> SongsForAlbum
        {
            get
            {
                songsForAlbum = SelectedAlbum.Songs;
                if (songsForAlbum.Count > 0)
                {
                    SelectedSong = songsForAlbum[0];
                }
                return songsForAlbum;
            }
        }

        private int numberOfSongs = 0;
        public int NumberOfSongs
        {
            get
            {
                return numberOfSongs;
            }
            set
            {
                numberOfSongs = value;
            }
        }

        private Song selectedSong = null;
        public Song SelectedSong
        {
            get
            {
                return selectedSong;
            }
            set
            {
                selectedSong = value;
            }
        }
    }
}
