namespace Castoreum.Interface.Service.Config
{
    public interface IConfigManager
    {
        IConfig CreateConfigFile(string archiveName);
        void PlaceConfigFile(IConfig config, string fileName);
        void PlaceGitIgnore(string path);
        IConfig GetConfig(string file);
    }
}
