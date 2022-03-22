using Castoreum.Config.Models;
using Castoreum.Interface.Service.Config;
using System;
using System.IO;

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
            throw new NotImplementedException();
        }

        public void PlaceConfigFile(IConfig config)
        {
            throw new NotImplementedException();
        }

        public void PlaceGitIgnore(string path)
        {
            using (File.Create(".gitignore"))

            File.WriteAllText(
                ".gitignore",
                "# exclude file types\n*.zip\n*.z2f\n\n# exclude modules\nmodules/"
            );
        }
    }
}
