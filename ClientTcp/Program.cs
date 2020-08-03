using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace ClientTcp
{
    /// <summary>
    /// ReceiveMessageHandler delegate
    /// </summary>
    public delegate void ReceiveMessageHandler();
    /// <summary>
    /// SendMessageHandler delegate
    /// </summary>
    public delegate void SendMessageHandler();
    /// <summary>
    /// DisconnectHandler delegate
    /// </summary>
    public delegate void DisconnectHandler();
    /// <summary>
    /// Class Program
    /// </summary>
    public class Program
    {
        private static string host = "127.0.0.1";
        private static int port = 8040;
        private static TcpClient client;
        private static NetworkStream stream;
        /// <summary>
        ///  Property UserName
        /// </summary>
        public static string UserName { get; set; }
        /// <summary>
        /// Property Host
        /// </summary>
        public static string Host {get{return host;}set{host = value;}}
        /// <summary>
        /// Property Port
        /// </summary>
        public static int Port { get { return port; } set { port = value; } }
        /// <summary>
        /// Property Client
        /// </summary>
        public static TcpClient Client { get { return client; } set { client = value; } }
        /// <summary>
        ///  Property Stream
        /// </summary>
        public static NetworkStream Stream { get { return stream; } set { stream = value; } }



        /// <summary>
        /// Method Main(string[] args)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(60, 20);
            Console.Write("Введите свое имя: ");
            UserName = Console.ReadLine();
            client = new TcpClient();          

            try
            {
                client.Connect(host, port); //client connection
                stream = client.GetStream(); // we get a stream
                string message = UserName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart(handler1));
                receiveThread.Start(); //старт потока
                Console.WriteLine("Добро пожаловать, {0}", UserName);
                handler2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                handler();
            }
        }
        /// <summary>
        ///  Anonymous method handler2(sending messages)
        /// </summary>
        public static SendMessageHandler handler2 = () =>
        {
            Console.WriteLine("Введите сообщение: ");
          //  Console.ReadKey();
            while (true)
            {
                string message = Console.ReadLine();
                if ((message[0] >= 'А' && (message[0]) <= 'п') || (message[0] >= 'р' && (message[0]) <= 'ё'))
                {
                    Console.WriteLine("Подписались на событие handler33");                  
                    Transliterate.GetTranslitClients += l_GetTranslitClients;
                   
                    byte[] data = Encoding.Unicode.GetBytes(Transliterate.handler33(message));
                    stream.Write(data, 0, data.Length);                    
                }
                if (message[0] >= 'A' && message[0] <= 'z')
                {
                    Console.WriteLine("Подписались на событие handler34");
                    Transliterate1.GetTranslit1Clients += l_GetTranslit1Clients;

                    byte[] data = Encoding.Unicode.GetBytes(Transliterate1.handler34(message));
                    stream.Write(data, 0, data.Length);
                }

            }
        };
        /// <summary>
        ///  Anonymous method handler1(receiving messages)
        /// </summary>
        public static ReceiveMessageHandler handler1 = () =>
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // buffer for received data
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    Console.WriteLine(message);//message output
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //the connection was interrupted
                    Console.ReadLine();
                    handler();
                }
            }
        };

        /// <summary>
        /// Anonymous method handler(end of session)
        /// </summary>
        public static DisconnectHandler handler = () =>
        {
            if (stream != null)
                stream.Close();//shutdown stream
            if (client != null)
                client.Close();//disconnecting client
            Environment.Exit(0); //completion of the process
        };
        /// <summary>
        /// Method l_GetTranslitClients(string sourceText)
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        public static string l_GetTranslitClients(string sourceText)
        {            
            return Transliterate.handler33(sourceText);
        }
        /// <summary>
        /// Method l_GetTranslit1Clients(string sourceText)
        /// </summary>
        /// <param name="sourceText"></param>
        /// <returns></returns>
        public static string l_GetTranslit1Clients(string sourceText)
        {
            return Transliterate1.handler34(sourceText);
        }
    }    
}
