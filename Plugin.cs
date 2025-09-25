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
        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            aircraft = null;
            rot = Vector3.zero;
            rotString = string.Empty;
            NOMotionUDP = new UDPClient();

        }

        void Update()
        {
            GameManager.GetLocalAircraft(out aircraft);
            if (null != aircraft)
            {
                rotString = $"{aircraft.rb.angularVelocity.z},{aircraft.rb.angularVelocity.x},{aircraft.rb.angularVelocity.y}";
                NOMotionUDP.SendMotion(rotString);
            }
        }
    }
}
