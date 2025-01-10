using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abz_cli.utils
{
    public class helplogger
    {
        public static Dictionary<string, List<string>> Helps = new Dictionary<string, List<string>>();
        public static bool ph(string key)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("hh:mm")}] ");

            if (Helps[key] != null)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{key}: Got {Helps[key].Count} Lines of help. \n");

                foreach (var item in Helps[key])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"> {item}\n");
                }
            }
            else
            {
                logger.pe($"wtf's this: '{key}'");
            }
            return true;
        }
    }
    public class logger
    {
        public static bool pl(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("hh:mm")}] ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{Program.AppName}::log ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Msg}\n");
            return true;
        }
        public static bool plx(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Msg}\n");
            return true;
        }
        public static bool pe(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("hh:mm")}] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Program.AppName}::error ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Msg}\n");
            return true;
        }
        public static bool pee()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("hh:mm")}] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Program.AppName}::error ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"..!\n");
            return true;
        }
        public static bool ra(string Args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("hh:mm")}] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Program.AppName}::error ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"requires-args: {Args}\n");
            return true;
        }
    }
}
