using Prism.Mvvm;
using Microsoft.Practices.Prism.Commands;
using System.Linq;
using WpfMusicPlayer.Model;
using WpfMusicPlayer.Repository;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfMusicPlayer.ViewModels
{
    public class MusicPlayerViewViewModel : BindableBase
    {
        public MusicPlayerViewViewModel()
        {
            LoadMusicPlayerDataAsync();

            SortArtistsCommand = new DelegateCommand(SortArtists);
            SortAlbumsCommand = new DelegateCommand(SortAlbums);
            SortSongsCommand = new DelegateCommand(SortSongs);         
        }

        private async void LoadMusicPlayerDataAsync()
        {
            var repository = new MusicDataRepository();
            var musicPlayerData = await repository.LoadMusicDataModelAsync();
            Artists = (musicPlayerData != null) ? musicPlayerData.Artists : null;
        }

        private void LoadMusicPlayerData()
        {
            var repository = new MusicDataRepository();
            var musicPlayerData = repository.LoadMusicDataModel();
            Artists = (musicPlayerData != null) ? musicPlayerData.Artists : null;
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

                    NumberOfArtists = _artists.Count;
                }
            }         
        }

        public DelegateCommand SortArtistsCommand { get; private set; }
        private void SortArtists()
        {
            Artists = new ObservableCollection<Artist>(from artist in _artists orderby artist.Name select artist);
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

                   AlbumsForArtist = _selectedArtist.Albums;                  
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
                }

                return _albumsForArtist;
            }
            set
            {
                if (value != _albumsForArtist)
                {
                    _albumsForArtist = value;
                    OnPropertyChanged("AlbumsForArtist");

                    NumberOfAlbums = _albumsForArtist.Count;
                    SelectedAlbum = null;
                }
            }
        }

        public DelegateCommand SortAlbumsCommand { get; private set; }
        private void SortAlbums()
        {
            AlbumsForArtist = new ObservableCollection<Album>(from album in _albumsForArtist orderby album.Date select album);
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

                    SongsForAlbum = (null != _selectedAlbum) ? _selectedAlbum.Songs : 
                                    new ObservableCollection<Song>();                 
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
                }

                return _songsForAlbum;
            }
            set
            {
                if (value != _songsForAlbum)
                {
                    _songsForAlbum = value;
                    OnPropertyChanged("SongsForAlbum");

                    NumberOfSongs = _songsForAlbum.Count;
                }
            }
        }

        public DelegateCommand SortSongsCommand { get; private set; }
        private void SortSongs()
        {
            SongsForAlbum = new ObservableCollection<Song>(from song in _songsForAlbum orderby song.Title select song);
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
