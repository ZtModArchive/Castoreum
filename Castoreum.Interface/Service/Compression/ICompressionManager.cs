using Castoreum.Interface.Service.Config;
using System.IO;
using System.IO.Compression;

namespace Castoreum.Interface.Service.Compression
{
    public interface ICompressionManager
    {
        void BuildMod(ZipArchive archive, IConfig config, DirectoryInfo directoryInfo);
    }
}
