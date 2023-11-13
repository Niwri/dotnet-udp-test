using System;
using System.Collections;
using System.Collections.Generic;

namespace GameClient {

    
    public class ClientSend {
        private static void SendUDPData(Packet _packet) {
            _packet.WriteLength();
            Client.udp.SendData(_packet);
        }

        public static void UDPTestReceived() {
            using (Packet _packet = new Packet((int)ClientPackets.udpTestReceived)) {
                _packet.Write("Received a UDP packet.");
                SendUDPData(_packet);
            }
        }

        /*
            START IMPLEMENTING CLIENT SEND FUNCTIONS HERE
        */

        public static void UDPMovement(int ID) {
            using (Packet _packet = new Packet((int)ClientPackets.udpMovement)) {
                _packet.Write(ID);
                SendUDPData(_packet);
            }
        }

        

    }
}
