using ServerTcp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServerApplication
{
    /// <summary>
    /// Класс Program
    /// </summary>
    public class Program
    {
        static ServerObject server; // сервер
        static Thread listenThread; // потока для прослушивания
        /// <summary>
        /// Метод  Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(60, 20);
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(ServerObject.handler1));                
                listenThread.Start(); //старт потока
                ServerObject.AcceptClient += l_AcceptClient;
            }
            catch (Exception ex)
            {              
                ServerObject.handler4();
                Console.WriteLine(ex.Message);
            }

            /// <summary>
            /// Метод  l_AcceptClient(TcpClient tcpClient)
            /// </summary>
            /// <param name="tcpClient"></param>
           
        }
        public static void l_AcceptClient(TcpClient tcpClient)
        {
            Console.WriteLine("Подписались на событие handler1");
        }
    }
}
