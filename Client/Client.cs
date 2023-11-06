using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;

namespace GameClient {
    public static class Client {
        public static int dataBufferSize = 4096;

        public static string ip = "127.0.0.1";
        public static int port = 26950;
        public static int myId = 10;
        public static UDP udp;
        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;

        public static void Start() {
            udp = new UDP();
            InitializeClientData();
        }
        public class UDP {
            public UdpClient socket;
            public IPEndPoint endPoint;
            public UDP() {
                endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            }

            public void Connect(int _localPort) {
                socket = new UdpClient(_localPort);
                socket.Connect(endPoint);
                Console.WriteLine($"Connected to endpoint {endPoint.ToString()} on port {_localPort}");
                socket.BeginReceive(ReceiveCallback, null);

                using (Packet _packet = new Packet((int)ClientPackets.udpTestReceived)) {
                    ClientSend.UDPTestReceived(); // Sending Packet first time to register ID in server.
                }
            }

            public void SendData(Packet _packet) {
                try {
                    _packet.InsertInt(myId);
                    if (socket != null) {
                        socket.BeginSend(_packet.ToArray(), _packet.Length(), null, null);
                    }
                } catch (Exception _ex) {
                    Console.WriteLine($"Error sending data to server via UDP: {_ex}");
                }
            }
            private void ReceiveCallback(IAsyncResult _result) {
                try {
                    byte[] _data = socket.EndReceive(_result, ref endPoint);
                    socket.BeginReceive(ReceiveCallback, null);

                    if(_data.Length < 4) {
                        // TODO: Disconnect
                        return;
                    }

                    HandleData(_data);
                } catch {
                    // TODO: disconnect;
                }
            }

            private void HandleData(byte[] _data) {
                using (Packet _packet = new Packet(_data)) {
                    int _packetLength = _packet.ReadInt();
                    _data = _packet.ReadBytes(_packetLength);
                }

                ThreadManager.ExecuteOnMainThread(() => {
                    using (Packet _packet = new Packet(_data)) {
                        int _packetId = _packet.ReadInt();
                        packetHandlers[_packetId](_packet);
                    }
                });
            }
            
        }

        private static void InitializeClientData() {

            
            packetHandlers = new Dictionary<int, PacketHandler>() {
                {(int)ServerPackets.udpTest, ClientHandle.UDPTest},
                // Add more packet functions here! 
            };

            Console.WriteLine("Initialized packets.");
        }
    }
}