using System.Collections.ObjectModel;

namespace WpfMusicPlayer.Model
{
    public class Artist
    {
        public string Name { get; set; }
        public ObservableCollection<Album> Albums { get; set; }
    }
}
