using System.Net;
using System.Net.Sockets;

namespace SyntronMboxTools
{
    /// <summary>
    /// UDP communication wrapper for MBOX hardware
    /// Replaces VB6 Winsock control
    /// </summary>
    public class MboxUdpClient : IDisposable
    {
        private UdpClient? _udpClient;
        private IPEndPoint? _remoteEndPoint;
        private bool _disposed = false;

        /// <summary>
        /// Initialize UDP client with local and remote ports
        /// </summary>
        /// <param name="localPort">Local port to bind (Host TX Port)</param>
        /// <param name="remoteHost">Remote host IP address (default: 255.255.255.255 for broadcast)</param>
        /// <param name="remotePort">Remote port (MBOX RX Port)</param>
        public void Initialize(int localPort, string remoteHost, int remotePort)
        {
            try
            {
                // Close existing connection if any
                _udpClient?.Close();
                _udpClient?.Dispose();

                // Create new UDP client on specified local port
                _udpClient = new UdpClient(localPort);

                // Enable broadcast mode (required for 255.255.255.255)
                _udpClient.EnableBroadcast = false;

                // Parse remote host IP
                IPAddress remoteIP;
                if (remoteHost == "255.255.255.255")
                {
                    remoteIP = IPAddress.Broadcast;
                    _udpClient.EnableBroadcast = true;
                }
                else
                {
                    remoteIP = IPAddress.Parse(remoteHost);
                }

                _remoteEndPoint = new IPEndPoint(remoteIP, remotePort);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to initialize UDP client: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Send UDP packet to MBOX hardware
        /// </summary>
        /// <param name="data">Packet data to send (should be 50 bytes)</param>
        public void SendPacket(byte[] data)
        {
            if (_udpClient == null || _remoteEndPoint == null)
            {
                throw new InvalidOperationException("UDP client not initialized. Call Initialize() first.");
            }

            try
            {
                _udpClient.Send(data, data.Length, _remoteEndPoint);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to send UDP packet: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Close UDP connection
        /// </summary>
        public void Close()
        {
            _udpClient?.Close();
            _udpClient = null;
            _remoteEndPoint = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _udpClient?.Close();
                    _udpClient?.Dispose();
                    _udpClient = null;
                    _remoteEndPoint = null;
                }
                _disposed = true;
            }
        }
    }
}