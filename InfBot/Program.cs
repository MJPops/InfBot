using HelloApp;
using InfBot.Models;
using InfBot.UI;
using System;
using System.Linq;
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


            else if (e.CallbackQuery.Data == "I'm Matvey")
            {
                await client.EditMessageTextAsync(message.Chat.Id,
                    message.MessageId,
                    "Выберите предмет для редактирования:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.SubjectsEdit());
            }
            else if (e.CallbackQuery.Data == "ДиффурыEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Name == e.CallbackQuery.Data.Substring(0, 7)
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    
                }
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
            else if (message.Text == "I'm Matvey")
            {
                await client.SendTextMessageAsync(message.Chat.Id,
                    "Выберите предмет для редактирования:",
                    replyMarkup: Buttons.SubjectsEdit());
            }
            else if (message.Text.Substring(0, 2) == "id")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    Subject subject = new Subject { Id = message.Text.Substring(3) };
                    dataBase.Add(subject);
                    dataBase.SaveChanges();
                }
            }
        }
    }
}
