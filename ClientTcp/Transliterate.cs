using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ClientTcp
{
    /// <summary>
    /// Делегат GetTranslitHandler(string sourceText)
    /// </summary>
    /// <param name="sourceText"></param>
    /// <returns></returns>
    public delegate string GetTranslitHandler(string sourceText);
    /// <summary>
    /// Класс Transliterate
    /// </summary>
    public static class Transliterate
    {
        /// <summary>
        /// Dictionary translation
        /// </summary>
        static Dictionary<string, string> translation = new Dictionary<string, string>()
        {
            {"а", "a" },
            {"б", "b"},
            {"в", "v"},
            {"г", "g"},
            {"д", "d"},
            {"е", "e"},
            {"ё", "yo"},
            {"ж", "zh"},
            {"з", "z"},
            {"и", "i"},
            {"й", "j"},
            {"к", "k"},
            {"л", "l"},
            {"м", "m"},
            {"н", "n"},
            {"о", "o"},
            {"п", "p"},
            {"р", "r"},
            {"с", "s"},
            {"т", "t"},
            {"у", "u"},
            {"ф", "f"},
            {"х", "h"},
            {"ц", "c"},
            {"ч", "ch"},
            {"ш", "sh"},
            {"щ", "sch"},
            {"ъ", "j"},
            {"ы", "i"},
            {"ь", "j"},
            {"э", "e"},
            {"ю", "yu"},
            {"я", "ya"},
            {"А", "A"},
            {"Б", "B"},
            {"В", "V"},
            {"Г", "G"},
            {"Д", "D"},
            {"Е", "E"},
            {"Ё", "Yo"},
            {"Ж", "Zh"},
            {"З", "Z"},
            {"И", "I"},
            {"Й", "J"},
            {"К", "K"},
            {"Л", "L"},
            {"М", "M"},
            {"Н", "N"},
            {"О", "O"},
            {"П", "P"},
            {"Р", "R"},
            {"С", "S"},
            {"Т", "T"},
            {"У", "U"},
            {"Ф", "F"},
            {"Х", "H"},
            {"Ц", "C"},
            {"Ч", "Ch"},
            {"Ш", "Sh"},
            {"Щ", "Sch"},
            {"Ъ", "J"},
            {"Ы", "I"},
            {"Ь", "J"},
            {"Э", "E"},
            {"Ю", "Yu"},
            {"Я", "Ya"},
            {" ", "_"}
        };

        /// <summary>
        /// Anonymous method handler33(broadcast event)
        /// </summary>
        public static GetTranslitHandler handler33 = (string sourceText) =>
        {
            while (true)
            {
                try
                {
                    if (GetTranslitClients == null)
                    {
                        Console.WriteLine("Не подписались на событие handler33");
                        break;
                    }
                    if (GetTranslitClients != null)
                    {                       
                        StringBuilder ans = new StringBuilder();
                        for (int i = 0; i < sourceText.Length; i++)
                        {
                            if (translation.ContainsKey(sourceText[i].ToString()))
                            {
                                ans.Append(translation[sourceText[i].ToString()]);
                            }
                            else
                            {
                                ans.Append(sourceText[i].ToString());
                            }
                        }
                        return ans.ToString();
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Program.handler();
                }                
            }
            return null;           
        };
        /// <summary>
        /// GetTranslitClients event
        /// </summary>
        public static event GetTranslitHandler GetTranslitClients;
    }    
}
