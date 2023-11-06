using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;

namespace GameClient {
    public class ClientHandle {
        public static void Welcome(Packet _packet) {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Console.WriteLine($"Message from server: {_msg}");
            Client.myId = _myId;

            Client.udp.Connect((((IPEndPoint)Client.udp.socket.Client.LocalEndPoint).Port));
        }

        public static void UDPTest(Packet _packet) {
            string _msg = _packet.ReadString();

            Console.WriteLine($"Received packet via UDP. Contains message: {_msg}");
            ClientSend.UDPTestReceived();
        }
    }
    
    
}