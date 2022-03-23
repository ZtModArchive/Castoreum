using Castoreum.Interface.Service.Config;

namespace Castoreum.Interface.Service.Installation
{
    public interface IInstallationManager
    {
        IConfig InstallDependency(IConfig config, string packageName);
        IConfig InstallDevDependency(IConfig config, string packageName);
        void InstallPackage(string packageName);
        IConfig RemoveDependency(IConfig config, string packageName);
        IConfig RemoveDevDependency(IConfig config, string packageName);
    }
}
