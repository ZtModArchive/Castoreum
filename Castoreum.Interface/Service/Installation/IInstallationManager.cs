using Castoreum.Interface.Service.Config;

namespace Castoreum.Interface.Service.Installation
{
    public interface IInstallationManager
    {
        void InstallDependency(string packageName, IConfig config);
        void InstallDevDependency(string packageName, IConfig config);
        void RemoveDependency(string packageName, IConfig config);
    }
}
