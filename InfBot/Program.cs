using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace InfBot
{
    class Program
    {
        private static string token { get; set; } = "Token";
        private static TelegramBotClient client;


        [Obsolete]
        static void Main()
        {
            try
            {
                client = new TelegramBotClient(token);
                client.StartReceiving();
                client.OnMessage += OnMessageHandler;
                client.OnCallbackQuery += OnCallbackQweryHandlerAsync;
                Console.ReadLine();
                client.StopReceiving();
            }
            catch
            {
                Console.WriteLine("ERROR");
            }
        }

        [Obsolete]
        private static async void OnCallbackQweryHandlerAsync(object sender, CallbackQueryEventArgs e)
        {
            //Привет
        }

        [Obsolete]
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {

        }
    }
}
