using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightgearPort
{
    /// <summary>
    /// Udp client wrapper. Sends selected object to a localhost port 
    /// </summary>
    /// <typeparam name="SendDataType"></typeparam>
    public class PortClient <SendDataType>
    {
        System.Net.Sockets.UdpClient sendClient;
        public bool ConnectionExists;
        public bool ConnectionCreated
        {
            get
            {
                return ConnectionExists;
            }
        }
        int port;

        public PortClient()
        {
            ConnectionExists = false;
        }

        /// <summary>
        /// Create sending connectionn to a localhost port
        /// </summary>
        /// <param name="port">Port number</param>
        /// <returns></returns>
        public bool CreateConnection(int port)
        {
            try
            {
                this.sendClient = new System.Net.Sockets.UdpClient(this.port = port);
                ConnectionExists = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Breaks the connection and dispose port resources
        /// </summary>
        public void BreakConnection()
        {
            if (!ConnectionExists) return;
            sendClient.Close();
            sendClient = null;
            ConnectionExists = false;
        }

        /// <summary>
        /// Sends data to the selected port. Data type should override ToString() method correctly
        /// </summary>
        /// <param name="data">Data to send</param>
        public void Send(SendDataType data)
        {
            if (!ConnectionExists) return;
            string str = data.ToString() + '\n';
            byte[] sendingBytes = System.Text.Encoding.ASCII.GetBytes(str);
            sendClient.Send(sendingBytes, sendingBytes.Length, "127.0.0.1", port);
        }
    }
}