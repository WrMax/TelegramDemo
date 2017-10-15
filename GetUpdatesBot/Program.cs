using GetUpdatesBot.Services;
using System;

namespace GetUpdatesBot
{
    class Program
    {
        static void Main(string[] args)
        {
            BotService.Instance.Connect();
            Console.ReadLine();
            BotService.Instance.Disconnect();
        }
    }
}
