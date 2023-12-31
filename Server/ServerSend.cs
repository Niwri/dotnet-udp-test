using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer {
    class ServerSend {
        private static void SendUDPData(int _toClient, Packet _packet) {
            _packet.WriteLength();
            Server.clients[_toClient].udp.SendData(_packet);

        }

        private static void SendUDPDataToAll(Packet _packet) {
            _packet.WriteLength();
            for(int i = 1; i <= Server.MaxPlayers; i++) {
                Server.clients[i].udp.SendData(_packet);
            }
        }

        private static void SendUDPDataToAll(int _exceptClient, Packet _packet) {
            _packet.WriteLength();
            for(int i = 1; i <= Server.MaxPlayers; i++) {
                if(i != _exceptClient) {
                    Server.clients[i].udp.SendData(_packet);
                }
            }
        }

        public static void UDPTest(int _toClient) {
            using (Packet _packet = new Packet((int)ServerPackets.udpTest)) {
                _packet.Write("A test packet for UDP.");
                SendUDPData(_toClient, _packet);
            }
        }

        /*
            START IMPLEMENTING SERVER SEND FUNCTIONS HERE
        */
    }
}