using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
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
            // First try to load file from GitHub
            try
            {
                using (var webClient = new WebClient())
                {
                    var jsonUri = new Uri("https://gist.githubusercontent.com/edj-boston/77b2cdc0cad5b5d42219/raw/1366c213a5b0ae29f1d29d0bc1d22d29f2586068/music.json");
                    var jsonContents = await webClient.DownloadStringTaskAsync(jsonUri);
                    return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MusicPlayerData>(jsonContents));
                }
            }
            catch (Exception exception)
            {     
                // Need better error information, logging to console for now
                Console.WriteLine(@"Failed to load json music file asynchronously from internet, error " + exception.StackTrace);  
                      
                // Otherwise load it from local copy   
                using (var reader = new StreamReader("../../Assets/music.json"))
                {
                    var json = await reader.ReadToEndAsync();
                    return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MusicPlayerData>(json));
                }
            }
        }

        public MusicPlayerData LoadMusicDataModel()
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var jsonUri = new Uri("https://gist.githubusercontent.com/edj-boston/77b2cdc0cad5b5d42219/raw/1366c213a5b0ae29f1d29d0bc1d22d29f2586068/music.json");
                    var jsonContents = webClient.DownloadString(jsonUri);
                    return JsonConvert.DeserializeObject<MusicPlayerData>(jsonContents);
                }
            }
            catch (Exception exception)
            {
                // Need better error information, logging to console for now
                Console.WriteLine(@"Failed to load json music file from internet, error " + exception.StackTrace);

                // Otherwise load it from local copy   
                using (var reader = new StreamReader("../../Assets/music.json"))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<MusicPlayerData>(json);
                }
            }
        }
    }
}
