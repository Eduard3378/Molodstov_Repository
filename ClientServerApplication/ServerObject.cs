using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerTcp
{
    /// <summary>
    /// AcceptClientHandler delegate(TcpClient tcpClient)
    /// </summary>
    /// <param name="tcpClient"></param>
    public delegate void AcceptClientHandler(TcpClient tcpClient);
    /// <summary>
    /// BroadcastToClientsHandler delegate(string message, string id)
    /// </summary>
    /// <param name="message"></param>
    /// <param name="id"></param>
    public delegate void BroadcastToClientsHandler(string message, string id);
    /// <summary>
    /// ListenHandler delegate
    /// </summary>
    public delegate void ListenHandler();
    /// <summary>
    /// RemoveConnectionHandler delegate(string id)
    /// </summary>
    /// <param name="id"></param>
    public delegate void RemoveConnectionHandler(string id);
    /// <summary>
    /// AddConnectionHandler delegate(ClientObject clientObject)
    /// </summary>
    /// <param name="clientObject"></param>
    public delegate void AddConnectionHandler(ClientObject clientObject);
    /// <summary>
    /// DisconnectHandler delegate
    /// </summary>
    public delegate void DisconnectHandler();
    /// <summary>
    /// Class ServerObject
    /// </summary>
    public class ServerObject
    {
        /// <summary>
        /// Server for listening
        /// </summary>
        protected internal static TcpListener tcpListener; 
        /// <summary>
        /// TcpClient
        /// </summary>
        public static TcpClient tcpClient;        
        
        /// <summary>
        /// All connections
        /// </summary>
        public static List<ClientObject> clients = new List<ClientObject>();


        /// <summary>
        /// Anonymous method handler3(addition clientObject)
        /// </summary>
        public static AddConnectionHandler handler3 = (ClientObject clientObject) =>
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
                handler4();
            }
        };

        /// <summary>
        /// Anonymous method handler2(user disconnection)
        /// </summary>
        public static RemoveConnectionHandler handler2 = (string id) =>
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
                handler4();
            }
        };

        /// <summary>
        /// Anonymous method handler1(user connection)
        /// </summary>        
        public static ListenHandler handler1 = () =>
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
                handler4();
            }
        };

        /// <summary>
        /// Anonymous method handler(broadcast message to connected clients)
        /// </summary>        
        public static BroadcastToClientsHandler handler = (string message, string id)=>
        {           
            try
            {              
                byte[] data = Encoding.Unicode.GetBytes(message);               
                if (BroadcastToClients != null)
                {
                    for (int i = 0; i < clients.Count; i++)
                    {
                        if (clients[i].Id != id) // f the client id is not equal to the sender id
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
                handler4();
            }
        };

        /// <summary>
        /// Anonymous method handler4(disconnecting all clients)
        /// </summary>
        public static DisconnectHandler handler4 = () =>
        {
            tcpListener.Stop(); //server stop
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //disconnecting client
            }
            Environment.Exit(0); //completion of the process
        };

        /// <summary>
        /// AcceptClient event
        /// </summary>
        public static event AcceptClientHandler AcceptClient;
        /// <summary>
        /// BroadcastToClients event
        /// </summary>
        public static event BroadcastToClientsHandler BroadcastToClients;
        /// <summary>
        /// RemoveConnectionClients event
        /// </summary>
        public static event RemoveConnectionHandler RemoveConnectionClients;
        /// <summary>
        /// AddConnectionClients event
        /// </summary>
        public static event AddConnectionHandler AddConnectionClients;      

    }    
}
