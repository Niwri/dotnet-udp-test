using System;
using System.Collections.Generic;
using System.Text;
namespace GameClient {
    class GameLogic {

        
        public static void Update() {
            ThreadManager.UpdateMain();

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if(keyInfo.KeyChar == 'w')
                ClientSend.UDPMovement(1);
            else if (keyInfo.KeyChar == 's')
                ClientSend.UDPMovement(2);
            else if (keyInfo.KeyChar == 'a')
                ClientSend.UDPMovement(3);
            else if (keyInfo.KeyChar == 'd')
                ClientSend.UDPMovement(4);
        }
    }
}