using Castoreum.Interface.Service.Config;
using System.IO;
using System.IO.Compression;

namespace Castoreum.Interface.Service.Compression
{
    public interface ICompressionManager
    {
        void CreateArchive(ZipArchive archive, IConfig config, DirectoryInfo directoryInfo);
        void AddToArchive(ZipArchive archive, IConfig config, DirectoryInfo directoryInfo);
    }
}
