using Rocket.API;
using Rocket.Unturned.Chat;
using System.Collections.Generic;

namespace MaintenenceMode
{
    public class MaintenanceModeCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "MaintenanceMode";

        public string Help => "Enables or disables maintenance mode";

        public string Syntax => "MaintenanceMode [enabled/disabled]";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "MaintenanceMode.MaintenanceMode" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say(caller, Syntax);
                return;
            }

            var state = command[0].ToLower();

            if (state == "enabled")
            {
                MaintenanceMode.SetMaintenanceModeActive(true);
                UnturnedChat.Say(caller, "Maintenance Mode Enabled.");
            }
            else if (state == "disabled")
            {
                MaintenanceMode.SetMaintenanceModeActive(false);
                UnturnedChat.Say(caller, "Maintenance Mode Disabled.");
            }
            else
            {
                UnturnedChat.Say(caller, Syntax);
            }
        }
    }
}