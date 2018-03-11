using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Loopback, 1234);
            server.Bind(ip);
            StreamReader sr = new StreamReader("../../TxtSever.txt");
            string readFile = sr.ReadToEnd();
            sr.Close();
            server.Listen(4);
            Socket client = server.Accept();
            byte[] receive = new byte[1024 * 60];
            int rec = client.Receive(receive);
            string serverReceive = Encoding.ASCII.GetString(receive, 0, rec);
            Console.WriteLine("Client gui: " + serverReceive);
            byte[] send = Encoding.ASCII.GetBytes(readFile);
            client.Send(send);
        }
    }
}
