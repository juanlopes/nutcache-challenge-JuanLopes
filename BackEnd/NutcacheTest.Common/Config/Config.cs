namespace NutcacheTest.Common.Config;

public interface IConfig {
    public string GetConnectionString();
}

public class Config : IConfig
{
    private const string HOST = "";
    private const string DB_NAME = "";
    private const string USER = "";
    private const string PASSWORD = "";
    
    public string GetConnectionString()
    {
        return $"server={HOST};database={DB_NAME};user={USER};password={PASSWORD}";
    }
}
