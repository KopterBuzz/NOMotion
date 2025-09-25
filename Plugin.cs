using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace NOMotion
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        private Aircraft aircraft;
        private Vector3 rot;
        private string rotString;
        private UDPClient NOMotionUDP;
        private bool isKillSwitch = false;
        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            Configuration.InitSettings(Config);
            aircraft = null;
            rot = Vector3.zero;
            rotString = string.Empty;
            NOMotionUDP = new UDPClient();

        }

        void Update()
        {
            if (Configuration.KillSwitch.Value.IsDown())
            {
                isKillSwitch = !isKillSwitch;
                if (isKillSwitch)
                {
                    Logger?.LogInfo("Kill Switch is ON!");
                }
            }
            GameManager.GetLocalAircraft(out aircraft);
            if (null != aircraft && !isKillSwitch)
            {
                rotString = $"{aircraft.rb.angularVelocity.z},{aircraft.rb.angularVelocity.x},{aircraft.rb.angularVelocity.y}";
                NOMotionUDP.SendMotion(rotString);
            }
        }
    }
}
