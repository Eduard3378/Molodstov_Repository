using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientTcp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace ClientTcp.Tests
{
    /// <summary>
    /// Class ProgramTests
    /// </summary>
    [TestClass()]
    public class ProgramTests
    {
        private static TcpClient client;
        private static NetworkStream stream;
        /// <summary>
        /// Method Handler_ClientObject_Exit()
        /// </summary>
        [TestMethod]
        public void Handler_ClientObject_Exit()
        {
            //  ServerObject.handler2(string id);
            Program.handler = () =>
            {
                if (stream != null)
                    stream.Close();//shutdown stream
                if (client != null)
                    client.Close();//disconnecting client
                Environment.Exit(0); //completion of the process
            };
        }
        /// <summary>
        ///  Method Handler1_ClientObject_ReceiveMessage()
        /// </summary>
        [TestMethod]
        public void Handler1_Message_ReceiveMessage()
        {
            //  ServerObject.handler2(string id);
            Program.handler1 = () =>
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
                        Console.WriteLine(message);//вывод сообщения
                    }
                    catch
                    {
                        Console.WriteLine("Подключение прервано!"); //the connection was interrupted
                        Console.ReadLine();
                        Program.handler();
                    }
                }
            };
        }
        /// <summary>
        /// Method Handler2_Message_SendMessage()
        /// </summary>
        [TestMethod]
        public void Handler2_Message_SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");
            //  ServerObject.handler2(string id);
            Program.handler2 = () =>
            {
                while (true)
                {
                    string message = Console.ReadLine();
                    if ((message[0] >= 'А' && (message[0]) <= 'п') || (message[0] >= 'р' && (message[0]) <= 'ё'))
                    {
                        Console.WriteLine("Подписались на событие handler33");
                        Transliterate.GetTranslitClients += Program.l_GetTranslitClients;

                        byte[] data = Encoding.Unicode.GetBytes(Transliterate.handler33(message));
                        stream.Write(data, 0, data.Length);
                    }
                    if (message[0] >= 'A' && message[0] <= 'z')
                    {
                        Console.WriteLine("Подписались на событие handler34");
                        Transliterate1.GetTranslit1Clients += Program.l_GetTranslit1Clients;

                        byte[] data = Encoding.Unicode.GetBytes(Transliterate1.handler34(message));
                        stream.Write(data, 0, data.Length);
                    }

                }
            };
        }

        /// <summary>
        /// Method l_GetTranslitClientsTest()
        /// </summary>
        [TestMethod()]
        public void l_GetTranslitClientsTest_String_Transliterate()
        {
            string sourceText = "Толя";
            Transliterate.GetTranslitClients += l_GetTranslitClients;
            Assert.IsNotNull(Transliterate.handler33(sourceText));
        }
        /// <summary>
        /// Method l_GetTranslit1ClientsTest()
        /// </summary>
        [TestMethod()]
        public void l_GetTranslit1ClientsTest()
        {
            string sourceText = "Коля";
            Transliterate1.GetTranslit1Clients += l_GetTranslit1Clients;
            Assert.IsNotNull(Transliterate1.handler34(sourceText));
        }



        public static string l_GetTranslitClients(string sourceText)
        {
            sourceText = "Подписались на событие GetTranslitClients";
            return sourceText;
        }
        public static string l_GetTranslit1Clients(string sourceText)
        {
            sourceText = "Подписались на событие GetTranslit1Clients";
            return sourceText;
        }
    }
}
