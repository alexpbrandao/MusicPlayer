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
            using (StreamReader reader = new StreamReader(@"C:\TestProjects\WpfMusicPlayer\WpfMusicPlayer\Assets\music.json"))
            {
                string json = await reader.ReadToEndAsync();
                return await Task.Factory.StartNew<MusicPlayerData>(() => JsonConvert.DeserializeObject<MusicPlayerData>(json));
            }
        }

        public MusicPlayerData LoadMusicDataModel()
        {
            using (StreamReader reader = new StreamReader(@"C:\TestProjects\WpfMusicPlayer\WpfMusicPlayer\Assets\music.json"))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<MusicPlayerData>(json);
            }
        }
    }
}
