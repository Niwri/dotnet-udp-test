using System;

namespace GameClient {
    class Program {
        public Program() {
        }

        public void Run() {
            Console.WriteLine("Hello World!");
            Client.Start();
            Client.udp.Connect(5005);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }
}
