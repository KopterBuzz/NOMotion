using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace NOMotion
{
    internal class Configuration
    {
        internal const string GeneralSettings = "General Settings";
        internal static ConfigEntry<KeyboardShortcut> KillSwitch;
        internal static KeyCode DefaultKillSwitch = KeyCode.F5;

        internal static ConfigEntry<int> Port;
        internal static int DefaultPort = 4123;

        internal static ConfigEntry<string> Address;
        internal static string DefaultAddress = "127.0.0.1";

        internal static void InitSettings(ConfigFile config)
        {
            KillSwitch = config.Bind("Hotkeys", "Kill Switch", new KeyboardShortcut(DefaultKillSwitch));
            Plugin.Logger?.LogDebug($"KillSwitch = {KillSwitch.Value}");

            Port = config.Bind(GeneralSettings, "Port", DefaultPort);
            Plugin.Logger?.LogDebug($"Port = {Port.Value}");

            Address = config.Bind(GeneralSettings, "Address", DefaultAddress);
            Plugin.Logger?.LogDebug($"Address = {Address.Value}");
        }
    }
}
