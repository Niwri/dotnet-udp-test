using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient {
    class GameLogic {
        public static void Update() {
            ThreadManager.UpdateMain();
            //ClientSend.UDPTestReceived();
        }
    }
}