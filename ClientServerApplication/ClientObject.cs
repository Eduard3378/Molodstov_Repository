using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerTcp
{
    /// <summary>
    /// Сlass ClientObject
    /// </summary>
    public class ClientObject
    {
        // private static NetworkStream stream;
        /// <summary>
        /// Property Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Property Stream
        /// </summary>
        public NetworkStream Stream { get; set; }
        string userName;
        TcpClient client;
        public ServerObject server; // server object
        string message;
        /// <summary>
        /// Constructor ClientObject
        /// </summary>
        /// <param name="tcpClient"></param>
        /// <param name="serverObject"></param>
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            ServerObject.AddConnectionClients += l_AddConnectionClients;
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
             ServerObject.handler3(this);
        }
        /// <summary>
        /// Method Process()
        /// </summary>
        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                // get username
                message = GetMessage();
                userName = message;
                message = userName + " присоединился к диологу";
                // we send a message about entering the chat to all connected users
                ServerObject.handler(message, Id);                              
                Console.WriteLine(message);
                ServerObject.BroadcastToClients += l_BroadcastToClients;
                // we receive messages from the client in an endless loop
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        Console.WriteLine(message);
                        ServerObject.handler(message, Id);                       
                    }
                    catch
                    {
                        message = String.Format("{0}: отсоединился от диолога", userName);
                        Console.WriteLine(message);
                        ServerObject.handler(message, Id);                       
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ServerObject.RemoveConnectionClients += l_RemoveConnectionClients;              
                ServerObject.handler2(Id);                
                Close();
            }
        }
        /// <summary>
        /// Method GetMessage()
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            byte[] data = new byte[64]; // buffer for received data
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                
            }
            while (Stream.DataAvailable);
            return builder.ToString();
        }
        /// <summary>
        /// Method Close()
        /// </summary>
        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }

        /// <summary>
        /// Method l_BroadcastToClients(string message, string id)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        public static void l_BroadcastToClients(string message, string id)
        {
            ClientObject clientObject=null; // server object
            ServerObject.handler(message, clientObject.Id);           
        }

        /// <summary>
        /// Method l_RemoveConnectionClients(string id)
        /// </summary>
        /// <param name="id"></param>
        public static void l_RemoveConnectionClients(string id)
        {
            ServerObject.handler2(id);
        }
        /// <summary>
        /// Method l_AddConnectionClients(ClientObject clientObject)
        /// </summary>
        /// <param name="clientObject"></param>
        public static void l_AddConnectionClients(ClientObject clientObject)
        {            
            ServerObject.handler3(clientObject);
        }        
    }
}
