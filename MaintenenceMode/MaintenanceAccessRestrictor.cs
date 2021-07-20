using ShimmyMySherbet.Moderation2.API.Interfaces;
using ShimmyMySherbet.Moderation2.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenenceMode
{
    public class MaintenanceAccessRestrictor : IAccessRestrictor
    {
        private MaintenanceMode m_Plugin;

        public MaintenanceAccessRestrictor(MaintenanceMode plugin)
        {
            m_Plugin = plugin;
        }

        public async Task<AccessGrant> Verify(QueuePlayer queuePlayer, CancellationToken cancellationToken)
        {
            if (m_Plugin.MaintenanceModeActive && !await queuePlayer.CheckPermissionAsync("MaintenanceMode.Pass"))
            {
                return AccessGrant.Deny("Server is currently under maintenance, check back soon");
            }

            return AccessGrant.Accept();
        }
    }
}