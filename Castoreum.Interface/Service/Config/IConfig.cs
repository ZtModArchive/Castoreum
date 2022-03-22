using System.Collections.Generic;

namespace Castoreum.Interface.Service.Config
{
    public interface IConfig
    {
        string ArchiveName { get; set; }
        string RepoName { get; set; }
        string Author { get; set; }
        string Version { get; set; }
        string Type { get; set; }
        string License { get; set; }
        string Description { get; set; }
        bool Z2f { get; set; }
        string ZT2loc { get; set; }
        IEnumerable<string> IncludeFolders { get; set; }
        IEnumerable<string> ExcludeFolders { get; set; }
        IEnumerable<string> Dependencies { get; set; }
        IEnumerable<string> DevDependencies { get; set; }
    }
}
