
namespace Pactas.SDK
{
    public enum SettingsProfile
    {
        Development = 0,
        Testing = 10,
        Sandbox = 20,
        Production = 100
    }

    public static class ConfigurationProfile
    {
        public static SettingsProfile ActiveProfile { get { return SettingsProfile.Development; } }
    }
}
