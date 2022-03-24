using Castoreum.Config.Models;
using Castoreum.Interface.Service.Config;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json;

namespace Castoreum.Config.Service
{
    public class ConfigManager : IConfigManager
    {
        public IConfig CreateConfigFile(string archiveName)
        {
            return new CastorConfig
            {
                ArchiveName = archiveName
            };
        }

        public IConfig GetConfig(string file)
        {
            string castorConfigText = File.ReadAllText(file);
            return JsonSerializer.Deserialize<CastorConfig>(castorConfigText);
        }

        public void PlaceConfigFile(IConfig config, string fileName)
        {
            string newJson = JToken.Parse(JsonSerializer.Serialize(config)).ToString();
            File.WriteAllText(fileName, newJson);
        }

        public void PlaceGitIgnore(string path)
        {
            File.WriteAllText(
                ".gitignore",
                "# exclude files\n*.zip\n*.z2f\ncastorlog.txt\n\n# exclude modules\nmodules/"
            );
        }
    }
}
