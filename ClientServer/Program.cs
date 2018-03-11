using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client.Connect(ipServer);
            string clientSend = "Send File Text1";
            byte[] send = Encoding.ASCII.GetBytes(clientSend);
            client.Send(send);
            byte[] receive = new byte[1024 * 60];
            int rec = client.Receive(receive);
            string clientReceive = Encoding.ASCII.GetString(receive, 0, rec);
            StreamWriter sw = new StreamWriter("..//..//TxtClient.txt");
            sw.Write(clientReceive);
            sw.Close();
        }
    }
}
