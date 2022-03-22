using Castoreum.Interface.Service.Config;
using System.Collections.Generic;

namespace Castoreum.Config.Models
{
    public class CastorConfig : IConfig
    {
        public string ArchiveName { get; set; }
        public string RepoName { get; set; } = "GitHubAccount/Reponame";
        public string Author { get; set; }
        public string Version { get; set; } = "v0.0.1";
        public string Type { get; set; } = "mod";
        public string License { get; set; }
        public string Description { get; set; } = "Lorem ipsum";
        public bool Z2f { get; set; } = true;
        public string ZT2loc { get; set; } = @"C:\Program Files (x86)\Microsoft Games\Zoo Tycoon 2";
        public IEnumerable<string> IncludeFolders { get; set; } = new List<string> {
                "ai",
                "awards",
                "biomes",
                "config",
                "effects",
                "entities",
                "lang",
                "locations",
                "maps",
                "materials",
                "photochall",
                "puzzles",
                "scenario",
                "scripts",
                "shared",
                "tourdata",
                "ui",
                "world",
                "xpinfo"
            };
        public IEnumerable<string> ExcludeFolders { get; set; }
        public IEnumerable<string> Dependencies { get; set; }
        public IEnumerable<string> DevDependencies { get; set; }
    }
}
