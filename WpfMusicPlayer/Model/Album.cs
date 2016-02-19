using System;
using System.Collections.ObjectModel;

namespace WpfMusicPlayer.Model
{
    public class Album
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
    }
}
