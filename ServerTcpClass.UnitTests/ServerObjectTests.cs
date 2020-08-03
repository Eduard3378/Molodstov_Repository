using ClientServerApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerTcpClass.UnitTests
{
    /// <summary>
    /// Class ServerObjectTests
    /// </summary>
    [TestClass]
    public class ServerObjectTests
    {
        /// <summary>
        /// ListenHandler delegate
        /// </summary>
        public delegate void ListenHandler();
        /// <summary>
        /// All connections
        /// </summary>
        List<ClientObject> clients = new List<ClientObject>();
        /// <summary>
        /// TcpClient
        /// </summary>
        TcpClient client;
        static TcpListener tcpListener;
        /// <summary>
        /// TcpClient
        /// </summary>
        static TcpClient tcpClient;
        /// <summary>
        /// Flow
        /// </summary>
        static Thread listenThread;
        static ServerObject server; // server object                                   

        /// <summary>
        /// AcceptClient event
        /// </summary>
        public static event AcceptClientHandler AcceptClient;
        /// <summary>
        /// RemoveConnectionClients event
        /// </summary>
        public static event RemoveConnectionHandler RemoveConnectionClients;
        /// <summary>
        /// AddConnectionClients event
        /// </summary>
        public static event AddConnectionHandler AddConnectionClients;
        /// <summary>
        /// BroadcastToClients event
        /// </summary>
        public static event BroadcastToClientsHandler BroadcastToClients;

        /// <summary>
        /// Method Handler1_TcpClientServer_Start()
        /// </summary>
        [TestMethod]
        public void Handler1_TcpClientServer_Start()
            => new Thread(new ThreadStart(ServerObject.handler1));
        /// <summary>
        /// Method Handler1_TcpClient_Start()
        /// </summary>
        [TestMethod]
        public void Handler1_TcpClient_Start()
        {
            ServerObject.handler1 = () =>
            {
                try
                {
                    ServerObject server = new ServerObject();
                    tcpListener = new TcpListener(IPAddress.Any, 8040);
                    tcpListener.Start();
                    Console.WriteLine("Сервер запущен. Ожидание подключений...");
                    while (true)
                    {
                        tcpClient = tcpListener.AcceptTcpClient();
                        // tcpClient = null;
                        if (AcceptClient == null)
                        {
                            Console.WriteLine("Не подписались на событие подключения пользователя");
                        }
                        if (AcceptClient != null)
                        {
                            AcceptClient(tcpClient);
                            ClientObject clientObject = new ClientObject(tcpClient, server);
                            Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                            clientThread.Start();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ServerObject.handler4();
                }
            };
        }
        /// <summary>
        /// Method Handler_TcpClient_Start() 
        /// </summary>
        [TestMethod]
        public void Handler_TcpClient_Start()
        {
            ServerObject.handler = (string message, string id) =>
            {
                try
                {
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    if (BroadcastToClients != null)
                    {
                        for (int i = 0; i < clients.Count; i++)
                        {
                            if (clients[i].Id != id) // if the client id is not equal to the sender id
                            {
                                clients[i].Stream.Write(data, 0, data.Length); //data transfer
                            }
                        }
                        Console.WriteLine("Подписались на событие handler");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ServerObject.handler4();
                }
            };
        }

        /// <summary>
        /// Method Main_TcpClient_L_AcceptClient()
        /// </summary>
        [TestMethod]
        public void Main_TcpClient_L_AcceptClient()
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(ServerObject.handler1));
                listenThread.Start(); //старт потока
                ServerObject.AcceptClient += Program.l_AcceptClient;
            }
            catch (Exception ex)
            {
                ServerObject.handler4();
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Method Handler2_Id_Remove()
        /// </summary>
        [TestMethod]
        public void Handler2_Id_Remove()
        {
            //  ServerObject.handler2(string id);
            ServerObject.handler2 = (string id) =>
            {
                try
                {
                    if (RemoveConnectionClients == null)
                    {
                        Console.WriteLine("Не подписались на событие отключения пользователя");
                    }
                    if (RemoveConnectionClients != null)
                    {
                        // we get a closed connection by id
                        ClientObject client = clients.FirstOrDefault(c => c.Id == id);
                        // and remove it from the list of connections
                        if (client != null)
                            clients.Remove(client);
                        Console.WriteLine("Подписались на событие handler2");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ServerObject.handler4();
                }
            };
        }
        /// <summary>
        /// Method Handler3_ClientObject_Add()
        /// </summary>
        [TestMethod]
        public void Handler3_ClientObject_Add()
        {
            //  ServerObject.handler2(string id);
            ServerObject.handler3 = (ClientObject clientObject) =>
            {
                try
                {
                    if (AddConnectionClients == null)
                    {
                        Console.WriteLine("Не подписались на событие добавления clientObject");
                    }
                    if (AddConnectionClients != null)
                    {
                        clients.Add(clientObject);
                        Console.WriteLine("Подписались на событие handler3");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ServerObject.handler4();
                }
            };
        }

        /// <summary>
        /// Method Handler4_ClientObject_Exit()
        /// </summary>
        [TestMethod]
        public void Handler4_ClientObject_Exit()
        {
            //  ServerObject.handler2(string id);
            ServerObject.handler4 = () =>
            {
                tcpListener.Stop(); //остановка сервера
                for (int i = 0; i < clients.Count; i++)
                {
                    clients[i].Close(); //отключение клиента
                }
                Environment.Exit(0); //завершение процесса
            };
        }
    }
}

