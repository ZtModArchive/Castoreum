using Castoreum.Interface.Service.Compression;
using Castoreum.Interface.Service.Config;
using System.IO;
using System.IO.Compression;

namespace Castoreum.Compression
{
    public class CompressionManager : ICompressionManager
    {
        public void BuildMod(ZipArchive archive, IConfig config, DirectoryInfo directoryInfo)
        {
            string[] directoryPath = Directory.GetCurrentDirectory().Split('\\');
            string rootDirectory = directoryPath[^1];
            string formattedPath = directoryInfo.FullName.Split(rootDirectory)[1].Remove(0, 1);

            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                if (config.Type == "module" || config.Type == "package")
                {
                    archive.CreateEntryFromFile(file.FullName, $"modules\\{config.RepoName}\\{formattedPath}\\{file.Name}");
                }
                archive.CreateEntryFromFile(file.FullName, $"{formattedPath}\\{file.Name}");
            }
            var directories = directoryInfo.GetDirectories();
            bool exclude;
            string subDirectoryPath;
            foreach (var directory in directories)
            {
                exclude = false;
                subDirectoryPath = directory.FullName.Split(rootDirectory)[1].Remove(0, 1);
                foreach (var excludedPath in config.ExcludeFolders)
                {
                    if (subDirectoryPath == excludedPath || subDirectoryPath == excludedPath.Replace('/', '\\'))
                        exclude = true;
                }

                foreach (var dependencyPath in config.Dependencies)
                {
                    if (subDirectoryPath == dependencyPath || subDirectoryPath == dependencyPath.Replace('/', '\\'))
                        exclude = true;
                }

                if (!exclude)
                    BuildMod(archive, config, directory);
            }
        }
    }
}
