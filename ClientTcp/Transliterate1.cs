using System;
using System.Collections.Generic;
using System.Text;

namespace ClientTcp
{
    /// <summary>
    /// Делегат  GetTranslit1Handler(string sourceText)
    /// </summary>
    /// <param name="sourceText"></param>
    /// <returns></returns>
    public delegate string GetTranslit1Handler(string sourceText);
    /// <summary>
    /// Класс Transliterate1
    /// </summary>
    public static class Transliterate1
    {
        /// <summary>
        /// Dictionary translation
        /// </summary>
        static Dictionary<string, string> translation = new Dictionary<string, string>()
        {
            {"a", "а" },
            {"b", "б"},
            {"v", "в"},
            {"g", "г"},
            {"d", "д"},
            {"e", "е"},
            {"j", "ж"},
            {"z", "з"},
            {"i", "и"},
            {"k", "к"},
            {"l", "л"},
            {"m", "м"},
            {"n", "н"},
            {"o", "о"},
            {"p", "п"},
            {"r", "р"},
            {"s", "с"},
            {"t", "т"},
            {"u", "у"},
            {"f", "ф"},
            {"h", "х"},
            {"c", "ц"},            
            {"w", "ш"},
            {"A", "А" },
            {"B", "Б"},
            {"V", "В"},
            {"G", "Г"},
            {"D", "Д"},
            {"E", "Е"},
            {"J", "Ж"},
            {"Z", "З"},
            {"I", "И"},
            {"K", "К"},
            {"L", "Л"},
            {"M", "М"},
            {"N", "Н"},
            {"O", "О"},
            {"P", "П"},
            {"R", "Р"},
            {"S", "С"},
            {"T", "Т"},
            {"U", "У"},
            {"F", "Ф"},
            {"H", "Х"},
            {"C", "Ц"},                       
            {" ", "_"}
        };

        /// <summary>
        /// Event handler34(broadcast event)
        /// </summary>
        public static GetTranslit1Handler handler34 = (string sourceText) =>
        {
            while (true)
            {
                try
                {
                    if (GetTranslit1Clients == null)
                    {
                        Console.WriteLine("Не подписались на событие handler34");
                        break;
                    }
                    if (GetTranslit1Clients != null)
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
        /// GetTranslit1Clients event
        /// </summary>
        public static event GetTranslit1Handler GetTranslit1Clients;
    }
}
