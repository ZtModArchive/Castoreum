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
                CompressionLevel compressionLevel;
                if (file.Extension.ToLower().Contains("jpg") || file.Extension.ToLower().Contains("jpeg"))
                    compressionLevel = CompressionLevel.NoCompression;
                else
                    compressionLevel = CompressionLevel.Fastest;

                if (config.Type == "module" || config.Type == "package")
                    archive.CreateEntryFromFile(file.FullName, $"modules\\{config.RepoName}\\{formattedPath}\\{file.Name}", compressionLevel);

                archive.CreateEntryFromFile(file.FullName, $"{formattedPath}\\{file.Name}", compressionLevel);
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

                foreach (var dependencyPath in config.DevDependencies)
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
