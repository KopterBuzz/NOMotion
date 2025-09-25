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
        private int udpPort = 4123;
        private string data;

        public UDPClient()
        {
            udp = new UdpClient();
            data = null;
        }

        public async void SendMotion(string data_)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data_);
            await udp?.SendAsync(bytes,bytes.Length,"127.0.0.1",udpPort);
            Plugin.Logger?.LogDebug(data_);
        }
    }
}
