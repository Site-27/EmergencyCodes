using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
using Exiled.Loader.Features.Configs.CustomConverters;

namespace EmergencyCodes
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Whether or not to color the facility lights when a code is activated. If false, lights will remain their normal color.")]
        public bool ColorLights { get; set; } = true;

        [Description("What CASSIE will say when a code is activated, and the custom subtitles attached to that message. {color} and {info} are REQUIRED.")]
        public string GenericCASSIEMessage { get; set; } = "$PITCH_0.20 .G3 .G3 .G3 $PITCH_0.90 ALL FACILITY PERSONNEL. THIS IS NOT A TEST. THERE HAS BEEN A CONFIRMED CODE {color}. THREAT DESIGNATED {info}. $PITCH_1.05 .G1 $PITCH_0.90 PLEASE REPORT TO THE DESIGNATED BREACH SHELTER AND WAIT FOR ORDERS FROM SECURITY. $PITCH_1.05 .G2 $PITCH_0.90 $PITCH_1.00 .G1.";
        public string GenericCASSIESubtitles { get; set; } = "ALL <color=yellow> [ FACILITY PERSONNEL ]. <color=white> THIS IS NOT A TEST. THERE HAS BEEN A CONFIRMED <color={hexcode}> [ CODE {color} ]. <color=white> THREAT DESIGNATED <color=red> [ {info} ]. <color=white> PLEASE REPORT TO THE <color=red> [ DESIGNATED BREACH SHELTER ] <color=white> AND WAIT FOR ORDERS FROM <color=grey> [ SECURITY ].";
        public string DisengageMessage { get; set; } = "$PITCH_0.90 CODE {color} DISENGAGED. $PITCH_1.05 .G1 $PITCH_0.90 PLEASE RESUME NORMAL OPERATIONS. $PITCH_1.05 .G2 $PITCH_0.90 $PITCH_1.00 .G1.";
        public string DisengageSubtitles { get; set; } = "<color={hexcode}> [ CODE {color} DISENGAGED ]. <color=white> PLEASE RESUME NORMAL OPERATIONS.";
    }
}
