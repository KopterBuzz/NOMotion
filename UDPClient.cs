using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using UnityEngine;

namespace NOMotion
{
    internal class UDPClient
    {
        UdpClient udp;


        public UDPClient()
        {
            udp = new UdpClient();
        }

        public async void SendMotion(string data_)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data_);
            await udp?.SendAsync(bytes,bytes.Length,Configuration.Address.Value,Configuration.Port.Value);
            Plugin.Logger?.LogDebug(data_);
        }
    }
}
