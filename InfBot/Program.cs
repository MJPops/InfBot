using InfBot.UI;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace InfBot
{
    class Program
    {
        private static string token { get; set; } = "2141405883:AAEKP5nIZlzPPLLcwQlHoN3fz3E9AklScAE";
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
            var message = e.CallbackQuery.Message;


            if (e.CallbackQuery.Data != null)
            {
                Console.WriteLine($"Нажата кнопка: {e.CallbackQuery.Data}");
            }

            if (e.CallbackQuery.Data == "Предметы")
            {
                await client.EditMessageTextAsync(
                    message.Chat.Id,
                    message.MessageId,
                    "Предметы:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.Subjects());
            }
        }

        [Obsolete]
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;


            if (message.Text != null)
            {
                Console.WriteLine($"Пришло сообщение: {message.Text}");
            }

            if (message.Text == "/start")
            {
                await client.SendTextMessageAsync(message.Chat.Id, Messages.Start, replyMarkup: Buttons.Start());
            }
        }
    }
}
