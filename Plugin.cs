using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using DefaultAutoFireMode.Patches;

namespace DefaultAutoFireMode
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "com.maschine.DefaultAutoFireMode";
        public const string PluginName = "maschine-DefaultAutoFireMode";
        public const string PluginVersion = "1.0.0";

        public static ManualLogSource Log;
        public static ConfigEntry<bool> Enabled;
        public static ConfigEntry<bool> DebugLog;

        private void Awake()
        {
            Log = Logger;

            Enabled = Config.Bind("General", "Enabled", true,
                "Switch to automatic fire mode when drawing a weapon that supports it.");
            DebugLog = Config.Bind("General", "DebugLog", false,
                "Log fire mode switches to the BepInEx console.");

            new ForceAutoFireModeOnDrawPatch().Enable();
            new ForceAutoFireModeOnWeapInPatch().Enable();

            Log.LogInfo($"{PluginName} v{PluginVersion} loaded.");
        }
    }
}
