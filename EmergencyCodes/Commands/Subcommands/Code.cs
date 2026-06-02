using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using UnityEngine;
using Exiled.API.Features;

namespace EmergencyCodes.Commands.Subcommands
{
    internal class ColorHandler
    {
        public Dictionary<string, (byte r, byte g, byte b)> rgbcolors = new Dictionary<string, (byte r, byte g, byte b)>
            {
                { "amber", ((byte)255, (byte)150, (byte)50) },
                { "blue", ((byte)155, (byte)200, (byte)255) },
                { "superblue", ((byte)155, (byte)200, (byte)255) },
                { "green", ((byte)200, (byte)255, (byte)200) },
                { "red", ((byte)255, (byte)200, (byte)200) },
                { "black", ((byte)200, (byte)200, (byte)200) },
                { "white", ((byte)200, (byte)200, (byte)200) },
                { "gray", ((byte)200, (byte)200, (byte)200) },
                { "supergray", ((byte)200, (byte)200, (byte)200) },
                { "magenta", ((byte)255, (byte)200, (byte)255) },
                { "yellow", ((byte)175, (byte)175, (byte)105) },
                { "aqua", ((byte)175, (byte)255, (byte)255) },
                { "orange", ((byte)255, (byte)150, (byte)50) },
                { "blank", ((byte)200, (byte)200, (byte)200) },
                { "superblank", ((byte)200, (byte)200, (byte)200) },
                { "coldsilver", ((byte)200, (byte)200, (byte)200) }
            };
        public void ColorFacilityLights(Color color)
        {
            foreach (var room in Room.List)
                room.Color = color;
        }
    }

    public class Code : ICommand
    {
        public string Command { get; } = "Code";
        public string[] Aliases { get; } = { "c" };
        public string Description { get; } = "Plays a CASSIE message to match the called code, and changes the facility lights to match the called code (if enabled in config).";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            // -1      0      1
            //code [color] [info]
            if (arguments.Count < 2)
            {
                response = "Requires both a code color and information on the threat. See #emergency-codes in the Discord server for a list of colors. Codes like superblue and superblank are ONE WORD.";
                return false;
            }

            string[] AllowedColors = new[] { "amber", "blue", "superblue", "green", "red", "black", "white", "grey", "gray", "supergray", "supergrey", "magenta", "yellow", "aqua", "orange", "blank", "superblank", "coldsilver" };

            string color = ((arguments.At(0)).ToLower());

            string info = string.Join(" ", arguments.Skip(1)).ToLower();

            if (!AllowedColors.Contains(color))
            {
                response = "Invalid code color. See #emergency-codes in the Discord server for a list of options.";
                return false;
            }

            if (color == "grey")
                color = "gray";
            else if (color == "supergrey")
                color = "supergray";

            var hexcode = new Dictionary<string, string>
            {
                { "amber", "#ffbf00" },
                { "blue", "#4169e1" },
                { "superblue", "#4169e1" },
                { "green", "#0ea626" },
                { "red", "#dc143c" },
                { "black", "black" },
                { "white", "white" },
                { "gray", "grey" },
                { "supergray", "grey" },
                { "magenta", "#ff00ff" },
                { "yellow", "yellow" },
                { "aqua", "#3ee4fa" },
                { "orange", "orange" },
                { "blank", "#c0c0c0" },
                { "superblank", "#c0c0c0" },
                { "coldsilver", "#c0c0c0" }
            };

            var colorhandler = new ColorHandler();
            var messenger = new AnnouncementSystem();

            if (info == "disengage")
            {
                messenger.cassieMessage = (Plugin.Instance.Config.DisengageMessage).Replace("{color}", color);
                messenger.cassieSubtitles = Plugin.Instance.Config.DisengageSubtitles
                    .Replace("{color}", color.ToUpper())
                    .Replace("{hexcode}", hexcode[color]);

                messenger.SendCassieMessage();

                if (Plugin.Instance.Config.ColorLights)
                    colorhandler.ColorFacilityLights(Color.white);

                response = $"Successfully disengaged Code {color}!";
                Log.Debug($"Code {color} disengaged. Cassie command:" + messenger.cassieMessage + " Cassie subtitles: " + messenger.cassieSubtitles);
                return true;
            }

            messenger.cassieMessage = messenger.cassieMessage.Replace("{color}", color);
            messenger.cassieMessage = messenger.cassieMessage.Replace("{info}", info);
            messenger.cassieSubtitles = messenger.cassieSubtitles.Replace("{color}", color.ToUpper());
            messenger.cassieSubtitles = messenger.cassieSubtitles.Replace("{info}", info.ToUpper());
            messenger.cassieSubtitles = messenger.cassieSubtitles.Replace("{hexcode}", hexcode[color]);

            messenger.SendCassieMessage();

            var (r, g, b) = colorhandler.rgbcolors[color];
            Color lightcolor = new Color(r / 255f, g / 255f, b / 255f);

            if (Plugin.Instance.Config.ColorLights)
                colorhandler.ColorFacilityLights(lightcolor);

            response = $"Successfully engaged Code {color} with info {info}!";
            Log.Debug($"Code {color} sent. Cassie command:" + messenger.cassieMessage + " Cassie subtitles: " + messenger.cassieSubtitles);
            return true;
        }
    }
}
