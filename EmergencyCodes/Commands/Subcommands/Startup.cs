using CommandSystem;
using System;
using System.Linq;

namespace EmergencyCodes.Commands.Subcommands
{
    public class Startup : ICommand
    {
        public string Command { get; } = "Startup";
        public string[] Aliases { get; } = { "s" };
        public string Description { get; } = "Plays the startup message.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            // -1        0          1
            //startup [number] [anomalies]

            if (arguments.Count < 2)
            {
                response = "Requires both the number of Class D personnel and the list of SCPs being tested on. If there is no testing, use 'none'.\nExample: announce startup 5 SCP 9 3 9 SCP 0 4 9";
                return false;
            }

            if (!int.TryParse(arguments.At(0), out int classDNumber))
            {
                response = "Invalid number of Class D personnel. Enter a whole number";
                return false;
            }

            string anomalies = string.Join(" ", arguments.Skip(1)).ToUpper();
            var messenger = new AnnouncementSystem();

            messenger.cassieMessage = Plugin.Instance.Config.StartupMessage.Replace("{number}", classDNumber.ToString()).Replace("{anomalies}", anomalies);
            messenger.cassieSubtitles = Plugin.Instance.Config.StartupSubtitles.Replace("{number}", classDNumber.ToString()).Replace("{anomalies}", anomalies);
            messenger.SendCassieMessage();

            response = "Played the startup message with " + classDNumber + " Class D personnel and anomalies: " + anomalies;
            return true;
        }
    }
}
