using Prism.Mvvm;
using WpfMusicPlayer.Model;
using WpfMusicPlayer.Repository;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfMusicPlayer.ViewModels
{
    public class MusicPlayerViewViewModel : BindableBase
    {
        public MusicPlayerViewViewModel()
        {
            LoadMusicPlayerDataAsync();         
        }

        private async void LoadMusicPlayerDataAsync()
        {
            var repository = new MusicDataRepository();
            var musicPlayerData = await repository.LoadMusicDataModelAsync();
            if (musicPlayerData != null)
            {
                Artists = musicPlayerData.Artists;
                NumberOfArtists = Artists.Count;
            }
        }

        private void LoadMusicPlayerData()
        {
            var repository = new MusicDataRepository();
            var musicPlayerData = repository.LoadMusicDataModel();
            if (musicPlayerData != null)
            {
                Artists = musicPlayerData.Artists;
                NumberOfArtists = Artists.Count;
            }
        }

        private ObservableCollection<Artist> _artists = new ObservableCollection<Artist>();        
        public ObservableCollection<Artist> Artists
        {
            get
            {
                return _artists;
            }   
            set
            {
                if (value != _artists)
                {
                    _artists = value;
                    OnPropertyChanged("Artists");
                }
            }         
        }

        private int _numberOfArtists = 0;
        public int NumberOfArtists
        {
            get
            {
                return _numberOfArtists;
            }
            set
            {
                if (value != _numberOfArtists)
                {
                    _numberOfArtists = value;
                    OnPropertyChanged("NumberOfArtists");
                }                
            }
        }

        private Artist _selectedArtist = null;
        public Artist SelectedArtist
        {
            get
            {
                return _selectedArtist;
            }
            set
            {
                if (value != _selectedArtist)
                {
                    _selectedArtist = value;
                    OnPropertyChanged("SelectedArtist");
                }
            }
        }

        private ObservableCollection<Album> _albumsForArtist = new ObservableCollection<Album>();
        public ObservableCollection<Album> AlbumsForArtist
        {
            get
            {
                if (SelectedArtist != null)
                {
                    _albumsForArtist = SelectedArtist.Albums;
                    if (_albumsForArtist.Count > 0)
                    {
                        SelectedAlbum = _albumsForArtist[0];
                    }
                }

                return _albumsForArtist;
            }
            set
            {
                if (value != _albumsForArtist)
                {
                    _albumsForArtist = value;
                    OnPropertyChanged("AlbumsForArtist");
                }
            }
        }

        private int _numberOfAlbums = 0;
        public int NumberOfAlbums
        {
            get
            {
                return _numberOfAlbums;
            }
            set
            {
                if (value != _numberOfAlbums)
                {
                    _numberOfAlbums = value;
                    OnPropertyChanged("NumberOfAlbums");
                }
            }
        }

        private Album _selectedAlbum = null;        
        public Album SelectedAlbum
        {
            get
            {
                return _selectedAlbum;
            }
            set
            {
                if (value != _selectedAlbum)
                {
                    _selectedAlbum = value;
                    OnPropertyChanged("SelectedAlbum");
                }
            }
        }

        private ObservableCollection<Song> _songsForAlbum = new ObservableCollection<Song>();
        public ObservableCollection<Song> SongsForAlbum
        {
            get
            {
                if (SelectedAlbum != null)
                {
                    _songsForAlbum = SelectedAlbum.Songs;
                    if (_songsForAlbum.Count > 0)
                    {
                        SelectedSong = _songsForAlbum[0];
                    }
                }

                return _songsForAlbum;
            }
            set
            {
                if (value != _songsForAlbum)
                {
                    _songsForAlbum = value;
                    OnPropertyChanged("SongsForAlbum");
                }
            }
        }

        private int _numberOfSongs = 0;
        public int NumberOfSongs
        {
            get
            {
                return _numberOfSongs;
            }
            set
            {
                if (value != _numberOfSongs)
                {
                    _numberOfSongs = value;
                    OnPropertyChanged("NumberOfSongs");
                }
            }
        }

        private Song _selectedSong = null;
        public Song SelectedSong
        {
            get
            {
                return _selectedSong;
            }
            set
            {
                if (value != _selectedSong)
                {
                    _selectedSong = value;
                    OnPropertyChanged("SelectedSong");
                }
            }
        }
    }
}
