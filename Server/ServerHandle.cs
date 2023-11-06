using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {

        public static void UDPTestReceived(int _fromClient, Packet _packet)
        {
            string _msg = _packet.ReadString();

            Console.WriteLine($"Received TEST packet via UDP. Contains message: {_msg}");
            
            Packet _newPacket = new Packet((int)ServerPackets.udpTest);
            ServerSend.UDPTest(_fromClient); // Can comment this out!
        }

        /* 
            IMPLEMENT PACKET HANDLER FUNCTIONS HERE!
        */
    }
}