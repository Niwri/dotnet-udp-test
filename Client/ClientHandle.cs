using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;


namespace GameClient {
    public class ClientHandle {
        public static void UDPTest(Packet _packet) {
            string _msg = _packet.ReadString();
            Console.WriteLine($"Received packet via UDP. Contains message: {_msg}");
        }

        /*
            START IMPLEMENTING PACKET HANDLERS FUNCTIONS HERE
        */

        
    }
    
    
}