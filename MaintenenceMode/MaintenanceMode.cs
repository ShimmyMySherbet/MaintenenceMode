using Rocket.API;
using Rocket.Core.Plugins;
using ShimmyMySherbet.Moderation2.API.Models;

namespace MaintenenceMode
{
    public class MaintenanceMode : RocketPlugin<Config>
    {
        public bool MaintenanceModeActive => Configuration.Instance.MaintenenceModeActive;

        private static MaintenanceMode m_Instance;
        public MaintenanceAccessRestrictor AccessRestrictor;

        public static void SetMaintenanceModeActive(bool active)
        {
            m_Instance.Configuration.Instance.MaintenenceModeActive = active;
            m_Instance.Configuration.Save();
        }

        public override void LoadPlugin()
        {
            base.LoadPlugin();
            m_Instance = this;

            AccessRestrictor = new MaintenanceAccessRestrictor(this);
            AccessRestrictions.RegisterSingleton(AccessRestrictor);
        }

        public override void UnloadPlugin(PluginState state = PluginState.Unloaded)
        {
            base.UnloadPlugin(state);

            AccessRestrictions.DeregisterSingleton(AccessRestrictor);
        }
    }
}