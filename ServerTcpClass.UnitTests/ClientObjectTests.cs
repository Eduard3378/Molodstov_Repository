using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerTcp;
using System;
using System.Net.Sockets;
using System.Text;
//using ClientTcp;
using System.Threading;
using System.Collections.Generic;
using System.Net;

namespace ServerTcp.Tests
{
    /// <summary>
    /// Class ClientObjectTests
    /// </summary>
    [TestClass()]
    public class ClientObjectTests
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Property Stream1
        /// </summary>
        public static NetworkStream Stream1 { get; set; }
        /// <summary>
        /// Property Stream
        /// </summary>
        public ClientObject Stream { get; set; }
        /// <summary>
        /// All connections
        /// </summary>
        public static List<ClientObject> clients = new List<ClientObject>();
        /// <summary>
        /// TcpClient
        /// </summary>
        TcpClient client;
        /// <summary>
        /// TcpClient
        /// </summary>
        TcpClient tcpClient;        
        static ServerObject server; // server object
        /// <summary>
        /// TcpListener
        /// </summary>
        static TcpListener tcpListener;       
        static ServerObject serverObject; // server object
        /// <summary>
        /// ClientObject
        /// </summary>
        ClientObject clientObject;


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
        /// Method ClientObject_TcpClientServerObject_CreateObject()
        /// </summary>
        [TestMethod()]
        public void ClientObject_TcpClientServerObject_CreateObject()
        {
            ServerObject.AddConnectionClients += ClientObject.l_AddConnectionClients;
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            ServerObject.handler3(clientObject);

        }
        /// <summary>
        /// Method Process_()
        /// </summary>
        [TestMethod()]
        public void Process_()
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
        /// Method GetMessage_String_String()
        /// </summary>
        [TestMethod()]
        public void GetMessage_String_String()
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
                            if (clients[i].Id != id) // если id клиента не равно id отправляющего
                            {
                                clients[i].Stream.Write(data, 0, data.Length); //передача данных
                                // clients[i].GetMessage();
                                Console.WriteLine(clients[i].GetMessage());
                            }
                            Console.WriteLine(clients[i].GetMessage());
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
        /// Method CloseTest()
        /// </summary>
        [TestMethod()]
        public void CloseTest()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
        /// <summary>
        /// Method l_BroadcastToClientsTest_MessageId_Handler()  
        /// </summary>
        [TestMethod()]
        public void l_BroadcastToClientsTest_MessageId_Handler()
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
                            ClientObject.l_BroadcastToClients("Толя", "0");                    
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
        /// Method l_RemoveConnectionClientsTest()
        /// </summary>
        [TestMethod()]
        public void l_RemoveConnectionClientsTest()
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
                            ClientObject.l_RemoveConnectionClients("0");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }
            };
        }
        /// <summary>
        /// Method l_AddConnectionClientsTest()
        /// </summary>
        [TestMethod()]
        public void l_AddConnectionClientsTest()
        {
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
                        ClientObject.l_AddConnectionClients(clientObject);
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
    }
}