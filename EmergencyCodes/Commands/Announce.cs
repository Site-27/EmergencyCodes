using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using EmergencyCodes.Commands.Subcommands;

namespace EmergencyCodes.Commands
{
    public class AnnouncementSystem
    {

        public string cassieMessage;
        public string cassieSubtitles;
        public void SendCassieMessage()
        {
            Exiled.API.Features.Cassie.MessageTranslated(cassieMessage, cassieSubtitles);
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Announce : ParentCommand
    {
        public Announce() => LoadGeneratedCommands();

        public override string Command { get; } = "Announce";
        public override string[] Aliases { get; } = { };
        public override string Description { get; } = "Play a custom CASSIE message.";

        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new Code());
            RegisterCommand(new Startup());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player player = Player.Get(sender);

            if (!player.RemoteAdminAccess)
            {
                response = "You do not have permission to use this command.";
                return false;
            }

            response = "Use one of the subcommands!";

            foreach (var command in AllCommands)
            {
                response += $"\n- {command.Command} ({string.Join(", ", command.Aliases)})";
            }

            return false;
        }
    }
}
