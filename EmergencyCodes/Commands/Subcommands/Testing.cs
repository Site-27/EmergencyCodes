using CommandSystem;
using System;
using System.Linq;

namespace EmergencyCodes.Commands.Subcommands
{
    public class Testing : ICommand
    {
        public string Command { get; } = "Testing";
        public string[] Aliases { get; } = { "t", "test" };
        public string Description { get; } = "Plays the testing message.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 3)
            {
                response = "Usage: announce testing [scps] room [room]\nExample: announce testing SCP 1 7 3 room HCZ 1 7 3";
                return false;
            }

            if (!arguments.ToArray().Contains("room"))
            {
                response = "You must specify a room using the keyword 'room'.\nExample: announce testing SCP 1 7 3 room HCZ 1 7 3";
                return false;
            }

            string anomalies = string.Join(" ", arguments.TakeWhile(arg => arg != "room"));
            string room = string.Join(" ", arguments.SkipWhile(arg => arg != "room").Skip(1));

            var messenger = new AnnouncementSystem();

            messenger.cassieMessage = Plugin.Instance.Config.TestingMessage.Replace("{anomalies}", anomalies).Replace("{room}", room);
            messenger.cassieSubtitles = Plugin.Instance.Config.TestingSubtitles.Replace("{anomalies}", anomalies).Replace("{room}", room);
            messenger.SendCassieMessage();

            response = "Playing testing message for " + anomalies + " in " + room;
            return true;
        }
    }
}
