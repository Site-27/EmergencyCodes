using System.ComponentModel;
using Exiled.API.Interfaces;

namespace EmergencyCodes
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Whether or not to color the facility lights when a code is activated. If false, lights will remain their normal color.")]
        public bool ColorLights { get; set; } = true;

        [Description("What CASSIE will say when a code is activated, and the custom subtitles attached to that message. {color} and {info} are REQUIRED.")]
        public string GenericCASSIEMessage { get; set; } = "$PITCH_0.20 .G3 .G3 .G3 $PITCH_0.90 ALL FACILITY PERSONNEL. THIS IS NOT A TEST. THERE HAS BEEN A CONFIRMED CODE {color}. THREAT DESIGNATED {info}. $PITCH_1.05 .G1 $PITCH_0.90 PLEASE REPORT TO THE DESIGNATED BREACH SHELTER AND WAIT FOR ORDER_SUFFIX_PLURAL_REGULAR FROM SECURITY. $PITCH_1.05 .G2 $PITCH_0.90 $PITCH_1.00 .G1.";
        public string GenericCASSIESubtitles { get; set; } = "ALL <color=yellow> [ FACILITY PERSONNEL ]. <color=white> THIS IS NOT A TEST. THERE HAS BEEN A CONFIRMED <color={hexcode}> [ CODE {color} ]. <color=white> THREAT DESIGNATED <color=red> [ {info} ]. <color=white> PLEASE REPORT TO THE <color=red> [ DESIGNATED BREACH SHELTER ] <color=white> AND WAIT FOR ORDERS FROM <color=grey> [ SECURITY ].";
        public string DisengageMessage { get; set; } = "$PITCH_0.90 CODE {color} DISENGAGED. $PITCH_1.05 .G1 $PITCH_0.90 PLEASE RESUME CONTINUE WITH NORMAL OPERATION _SUFFIX_PLURAL_REGULAR. $PITCH_1.05 .G2 $PITCH_0.90 $PITCH_1.00 .G1.";
        public string DisengageSubtitles { get; set; } = "<color={hexcode}> [ CODE {color} DISENGAGED ]. <color=white> PLEASE CONTINUE WITH NORMAL OPERATIONS.";

        public string StartupMessage { get; set; } = "$PITCH_0.07 $STUTT_5_5 .G4 $PITCH_0.55 START UP PROCEDURE HAS BEGUN . . $PITCH_0.60 .G1 Turning on Backup Power Bank . $PITCH_0.20 .G5 $PITCH_0.40 .G5 . $PITCH_0.30 .G5 $PITCH_0.70 <color=#1b3b19> Initializing Biological Scan . $PITCH_1.00 .G1 $PITCH_0.20 .G1 . $PITCH_0.70 <color=#30492e> Installing Broadcast Information . $PITCH_0.20 $STUTT_10_20 .G6 . $PITCH_0.75 Commencing Activation of Doors and Elevators . $PITCH_0.10 $STUTT_5_7 .G4 . $PITCH_0.80 Activating Facility Lights . $PITCH_0.30 .G1 $PITCH_0.60 .G1 $PITCH_0.80 .G1 . $PITCH_0.30 .G5 $PITCH_0.40 .G5 $PITCH_0.50 .G5 $PITCH_0.60 .G5 $PITCH_0.70 .G5 $PITCH_1.10 .G1 .G1 .G1 $PITCH_1.00 Welcome FACILITY PERSONNEL . There is an estimated amount of {number} CLASSD PERSONNEL . Testing has been confirmed on {anomalies} . Execute standard testing procedures . Cooperate with safety . $PITCH_0.50 $STUTT_5_10 .G4";
        public string StartupSubtitles { get; set; } = "<color=#131313>[ START UP PROCEDURE HAS BEGUN ] . .\n<color=#2c2c2c>Turning on Backup Power Bank.\n<color=#1b3b19>Initializing Biological Scan.\n<color=#30492e>Installing Broadcast Information.\n<color=#4c5d4b>Commencing Activation of Doors and Elevators.\n<color=#768b74>Activating Facility Lights.\n<color=#ffffff>Welcome <color=#ffff00> [ FACILITY PERSONNEL ]. <color=#ffffff>There is an estimated amount of <color=#ffa500> [ {number} ] [ CLASSD PERSONNEL ] <color=#ffffff>. Testing has been confirmed on <color=#ff0000> [ {anomalies} ] . <color=#28ff13>Execute standard testing procedures. <color=#81ff74>Cooperate with safety.";

    }
}
