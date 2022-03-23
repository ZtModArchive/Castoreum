using Castoreum.Config.Models;
using Castoreum.Interface.Service.Config;
using Castoreum.Interface.Service.Installation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Castoreum.Installation
{
    public class InstallationManager : IInstallationManager
    {
        public IConfig InstallDependency(IConfig config, string packageName)
        {
            InstallPackage(packageName);
            List<string> dependencies = (List<string>)config.Dependencies;
            if (!dependencies.Contains(packageName))
            {
                dependencies.Add(packageName);
            }
            return config;
        }

        public IConfig InstallDevDependency(IConfig config, string packageName)
        {
            InstallPackage(packageName);
            List<string> dependencies = (List<string>)config.DevDependencies;
            if (!dependencies.Contains(packageName))
            {
                dependencies.Add(packageName);
            }
            return config;
        }

        public IConfig RemoveDependency(IConfig config, string packageName)
        {
            UninstallPackage(packageName);
            List<string> dependencies = (List<string>)config.Dependencies;
            if (!dependencies.Contains(packageName))
            {
                dependencies.RemoveAll(p => p == packageName);
            }
            return config;
        }

        public IConfig RemoveDevDependency(IConfig config, string packageName)
        {
            UninstallPackage(packageName);
            List<string> dependencies = (List<string>)config.DevDependencies;
            if (!dependencies.Contains(packageName))
            {
                dependencies.RemoveAll(p => p == packageName);
            }
            return config;
        }

        public void InstallPackage(string packageName)
        {
            using WebClient client = new();
            Guid guid = Guid.NewGuid();
            string[] packageArgs = packageName.Split('/');
            client.DownloadFile($"https://github.com/{packageArgs[0]}/{packageArgs[1]}/archive/refs/tags/{packageArgs[2]}.zip", $"{guid}.zip");
            ZipFile.ExtractToDirectory($"{guid}.zip", $"{guid}");

            // remove the package's modules folder if the dev didn't exclude it
            if (Directory.Exists($"{guid}/modules"))
                Directory.Delete($"{guid}/modules");

            string[] subDirectories = Directory.GetDirectories($"{guid}");
            string firstSubDir = "";
            if (subDirectories.Length > 0)
            {
                firstSubDir = subDirectories[0];
            }

            CopyFilesRecursively($"{guid}/{firstSubDir.Split('\\')[1]}", $"modules/{packageArgs[0]}/{packageArgs[1]}");

            var directory = new DirectoryInfo($"{guid}") { Attributes = FileAttributes.Normal };
            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }

            Directory.Delete($"{guid}", true);
            File.Delete($"{guid}.zip");
        }

        private void UninstallPackage(string packageName)
        {
            if (Directory.Exists($"modules/{packageName}"))
                Directory.Delete($"modules/{packageName}");
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
