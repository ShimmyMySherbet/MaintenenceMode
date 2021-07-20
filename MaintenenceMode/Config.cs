using Rocket.API;

namespace MaintenenceMode
{
    public class Config : IRocketPluginConfiguration
    {
        public bool MaintenenceModeActive = false;

        public void LoadDefaults()
        {
        }
    }
}