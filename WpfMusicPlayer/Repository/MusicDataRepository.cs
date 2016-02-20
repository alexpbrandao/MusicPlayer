using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfMusicPlayer.Model;

namespace WpfMusicPlayer.Repository
{
    public class MusicDataRepository
    {
        public MusicDataRepository()
        {
        }

        public async Task<MusicPlayerData> LoadMusicDataModelAsync()
        {
            using (var reader = new StreamReader(@"C:\TestProjects\WpfMusicPlayer\WpfMusicPlayer\Assets\music.json"))
            {
                var json = await reader.ReadToEndAsync();
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MusicPlayerData>(json));
            }
        }

        public MusicPlayerData LoadMusicDataModel()
        {
            using (var reader = new StreamReader(@"C:\TestProjects\WpfMusicPlayer\WpfMusicPlayer\Assets\music.json"))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<MusicPlayerData>(json);
            }
        }
    }
}
