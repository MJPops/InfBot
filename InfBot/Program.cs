using HelloApp;
using InfBot.Models;
using InfBot.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace InfBot
{
    class Program
    {
        private static string token { get; set; } = "2141405883:AAEKP5nIZlzPPLLcwQlHoN3fz3E9AklScAE";
        private static TelegramBotClient client;


        [Obsolete]
        static async Task Main()
        {
            try
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubjects = dataBase.Subjects.ToList();
                    if (!selectedSubjects.Any())
                    {
                        dataBase.Add(new Subject { Id = "1", Name = "Диффуры"});
                        dataBase.Add(new Subject { Id = "1", Name = "Диффуры" });
                        dataBase.Add(new Subject { Id = "2", Name = "Физика" });
                        dataBase.Add(new Subject { Id = "3", Name = "МСОПР" });
                        dataBase.Add(new Subject { Id = "4", Name = "Физ-ра" });
                        dataBase.Add(new Subject { Id = "5", Name = "ТОИ" });
                        dataBase.Add(new Subject { Id = "6", Name = "Социология" });
                        dataBase.Add(new Subject { Id = "7", Name = "Философия" });
                        dataBase.Add(new Subject { Id = "8", Name = "Программирование" });
                        dataBase.Add(new Subject { Id = "9", Name = "ТВИМС" });
                        dataBase.Add(new Subject { Id = "10", Name = "ИнЯз" });
                        await dataBase.SaveChangesAsync();
                    }
                }

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

            if (e.CallbackQuery.Data == "/start")
            {
                await client.SendTextMessageAsync(message.Chat.Id, Messages.Start, replyMarkup: Buttons.Start());
            }
            else if (e.CallbackQuery.Data == "Предметы")
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
                Subject.subjectToChange = null;
            }
            else if (e.CallbackQuery.Data == "ДиффурыEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "1"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "1";
                }
            }
            else if (e.CallbackQuery.Data == "ФизикаEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "2"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "2";
                }
            }
            else if (e.CallbackQuery.Data == "Физ-раEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "3"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "3";
                }
            }
            else if (e.CallbackQuery.Data == "ТОИEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "4"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "4";
                }
            }
            else if (e.CallbackQuery.Data == "ФилософияEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "5"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "5";
                }
            }
            else if (e.CallbackQuery.Data == "СоциологияEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "6"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "6";
                }
            }
            else if (e.CallbackQuery.Data == "ПрограммированиеEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "7"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "7";
                }
            }
            else if (e.CallbackQuery.Data == "МСОПРEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "8"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "8";
                }
            }
            else if (e.CallbackQuery.Data == "ТВИМСEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "9"
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
                Subject.subjectToChange = "9";
            }
            else if (e.CallbackQuery.Data == "ИнЯзEdit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "10"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Дз: {subject.HomeWork}\n\n" +
                            $"Материалы: {subject.SubjectLink}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "10";
                }
            }

            else if (e.CallbackQuery.Data == "Домашку")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Введите дз (для переноса текста на новую строку пишите символ \\n");
                Subject.parametrSetingStatus = "Домашку";
            }
            else if (e.CallbackQuery.Data == "Материалы")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Введите ссылку на материалы");
                Subject.parametrSetingStatus = "Материалы";
            }

            else if (e.CallbackQuery.Data == "Диффуры")
            {
                await client.EditMessageTextAsync(
                    message.Chat.Id,
                    message.MessageId,
                    "Диффуры:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
            }
            else if (e.CallbackQuery.Data == "Расписание")
            {
                await client.SendPhotoAsync(message.Chat.Id, Links.Timetable, replyMarkup: Buttons.Start());
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
            else if (Subject.parametrSetingStatus != null)
            {
                if (Subject.parametrSetingStatus == "Домашку")
                {
                    using (ApplicationContext dataBase = new ApplicationContext())
                    {
                        var selectedSubject = from subject in dataBase.Subjects.ToList()
                                              where subject.Id == Subject.subjectToChange
                                              select subject;

                        foreach (Subject subject in selectedSubject)
                        {
                            subject.HomeWork = message.Text;
                        }
                        await dataBase.SaveChangesAsync();
                        await client.SendTextMessageAsync(message.Chat.Id, "Изменено", replyMarkup: Buttons.BackToEdit());
                    }
                }
                else if (Subject.parametrSetingStatus == "Материалы")
                {
                    using (ApplicationContext dataBase = new ApplicationContext())
                    {
                        var selectedSubject = from subject in dataBase.Subjects.ToList()
                                              where subject.Id == Subject.subjectToChange
                                              select subject;

                        foreach (Subject subject in selectedSubject)
                        {
                            subject.SubjectLink = message.Text;
                        }
                        await dataBase.SaveChangesAsync();
                        await client.SendTextMessageAsync(message.Chat.Id, "Изменено", replyMarkup: Buttons.BackToEdit());
                    }
                }
                Subject.parametrSetingStatus = null;
                Subject.subjectToChange = null;
            }
        }
    }
}
