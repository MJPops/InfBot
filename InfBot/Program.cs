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
                Console.ReadLine();
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
            else if (e.CallbackQuery.Data == "<<Назад")
            {
                await client.EditMessageTextAsync(message.Chat.Id,
                    message.MessageId,
                    Messages.Start,
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.Start());
            }
            else if (e.CallbackQuery.Data == "Предметы")
            {
                await client.EditMessageTextAsync(
                    message.Chat.Id,
                    message.MessageId,
                    "Предметы:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.Subjects());
            }

            else if (e.CallbackQuery.Data == "Расписание")
            {
                await client.SendPhotoAsync(message.Chat.Id, Links.Timetable, replyMarkup: Buttons.BackToStart());
            }

            else if (e.CallbackQuery.Data == "Диффуры")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "1"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Диффуры Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link,subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Диффуры Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Диффуры Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Диффуры Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "1";
                }
            }
            else if (e.CallbackQuery.Data == "Физика")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "2"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Физика Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Физика Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Физика Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Физика Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "2";
                }
            }
            else if (e.CallbackQuery.Data == "МСОПР")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "3"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"МСОПР Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"МСОПР Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"МСОПР Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"МСОПР Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "3";
                }
            }
            else if (e.CallbackQuery.Data == "Физ-ра")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "4"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Физ-ра Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Физ-ра Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Физ-ра Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Физ-ра Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "4";
                }
            }
            else if (e.CallbackQuery.Data == "ТОИ")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "5"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"ТОИ Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"ТОИ Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"ТОИ Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"ТОИ Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "5";
                }
            }
            else if (e.CallbackQuery.Data == "Социология")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "6"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Социология Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Социология Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Социология Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Социология Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "6";
                }
            }
            else if (e.CallbackQuery.Data == "Философия")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "7"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Философия Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Философия Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Философия Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Философия Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "7";
                }
            }
            else if (e.CallbackQuery.Data == "Программирование")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "8"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"Программирование Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"Программирование Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"Программирование Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"Программирование Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "8";
                }
            }
            else if (e.CallbackQuery.Data == "ТВИМС")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "9"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"ТВИМС Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"ТВИМС Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"ТВИМС Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"ТВИМС Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "9";
                }
            }
            else if (e.CallbackQuery.Data == "ИнЯз")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedSubject = from subject in dataBase.Subjects.ToList()
                                          where subject.Id == "10"
                                          select subject;

                    foreach (Subject subject in selectedSubject)
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"ИнЯз Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.Link, subject.LinkToLesson));

                        }
                        catch
                        {
                            try
                            {
                                await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"ИнЯз Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                    Buttons.InSubject(subject.Link));

                            }
                            catch
                            {
                                try
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                        message.MessageId,
                                        $"ИнЯз Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                        Buttons.InSubject(subject.LinkToLesson));

                                }
                                catch
                                {
                                    await client.EditMessageTextAsync(message.Chat.Id,
                                            message.MessageId,
                                            $"ИнЯз Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                                }
                            }
                        }
                    }
                    Subject.subjectToChange = "10";
                }
            }


            else if (e.CallbackQuery.Data == "Im Matvey")
            {
                await client.EditMessageTextAsync(message.Chat.Id,
                    message.MessageId,
                    "Выберите предмет для редактирования:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.SubjectsEdit());
                Subject.subjectToChange = null;
                BotUser.Maling = false;
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
                            $"Диффуры {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"Физика {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"Физ-ра {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"ТОИ {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"Философия {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"Социология {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"Программирование {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"МСОПР {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"ТВИМС {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
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
                            $"ИнЯз {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"Что вы хотите изменить? {subject.Link ?? "Ссылки нет"}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
                    }
                    Subject.subjectToChange = "10";
                }
            }

            else if (e.CallbackQuery.Data == "Домашку")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Введите Д/З");
                Subject.parametrSetingStatus = "Домашку";
            }
            else if (e.CallbackQuery.Data == "Материалы")
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Введите ссылку на материалы");
                Subject.parametrSetingStatus = "Материалы";
            }


            else if (e.CallbackQuery.Data == "Пользователи")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var users = dataBase.BotUsers.ToList();

                    if (users.Any())
                    {
                        foreach (BotUser user in users)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id,
                                $"{user.Name}:",
                                replyMarkup: Buttons.UserWithId(user.Id));
                        }
                        await client.SendTextMessageAsync(message.Chat.Id,
                            $"Ваш Id -- {message.Chat.Id}",
                            replyMarkup: Buttons.BackToEdit());
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Нет зарегистрированных пользователей");
                    }
                }
            }
            else if (e.CallbackQuery.Data == "Рассылка")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var users = dataBase.BotUsers.ToList();

                    if (users.Any())
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            "Введите сообщение для рассылки",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.BackToEdit());
                        BotUser.Maling = true;
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Нет зарегистрированных пользователей");
                    }
                }

            }

            else if (e.CallbackQuery.Data.Substring(0, 2) == "id")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedUser = from user in dataBase.BotUsers.ToList()
                                       where user.Id == e.CallbackQuery.Data.Substring(2)
                                       select user;

                    foreach (BotUser user in selectedUser)
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"Имя: {user.Name}\n\n" +
                            $"Id: {user.Id}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.UserModification(user.Id));
                    }
                }
            }
            else if (e.CallbackQuery.Data.Substring(0, 3) == "del")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedUser = from user in dataBase.BotUsers.ToList()
                                       where user.Id == e.CallbackQuery.Data.Substring(3)
                                       select user;

                    foreach (BotUser user in selectedUser)
                    {
                        await client.SendTextMessageAsync(user.Id, "Вас удалили из списка зарегистрированных пользователей");
                        dataBase.Remove(user);
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            "Пользователь удален");
                    }
                    await dataBase.SaveChangesAsync();
                }
            }
            else if (e.CallbackQuery.Data.Substring(0, 4) == "edit")
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    var selectedUser = from user in dataBase.BotUsers.ToList()
                                       where user.Id == e.CallbackQuery.Data.Substring(4)
                                       select user;

                    foreach (BotUser user in selectedUser)
                    {
                        BotUser.NameChanging = true;
                        BotUser.IdToChange = e.CallbackQuery.Data.Substring(4);
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            "Введите новое имя");
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

            try
            {
                if (message.Text == "/start")
                {
                    await client.SendTextMessageAsync(message.Chat.Id, Messages.Start, replyMarkup: Buttons.Start());
                }
                else if (message.Text == "Заполнить предметы")
                {
                    await Subject.AddStandartSubjectsAsync();
                    await client.SendTextMessageAsync(message.Chat.Id, "Данные по предметам заполнены");
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
                                subject.Link = message.Text;
                            }
                            await dataBase.SaveChangesAsync();
                            await client.SendTextMessageAsync(message.Chat.Id, "Изменено", replyMarkup: Buttons.BackToEdit());
                        }
                    }
                    Subject.parametrSetingStatus = null;
                    Subject.subjectToChange = null;
                }
                else if (BotUser.Maling)
                {
                    using (ApplicationContext dataBase = new ApplicationContext())
                    {
                        var users = dataBase.BotUsers.ToList();

                        if (users.Any())
                        {
                            foreach (BotUser user in users)
                            {
                                await client.SendTextMessageAsync(user.Id, message.Text);
                            }
                        }
                        else
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Нет зарегистрированных пользователей");
                        }
                    }
                    BotUser.Maling = false;
                    await client.SendTextMessageAsync(message.Chat.Id, "Сообщение отправлено", replyMarkup: Buttons.BackToEdit());
                }
                else if (BotUser.NameChanging)
                {
                    using (ApplicationContext dataBase = new ApplicationContext())
                    {
                        var selectedUser = from user in dataBase.BotUsers.ToList()
                                           where user.Id == BotUser.IdToChange
                                           select user;

                        foreach (BotUser user in selectedUser)
                        {
                            user.Name = message.Text;
                            await client.SendTextMessageAsync(message.Chat.Id, "Имя заменено", replyMarkup: Buttons.BackToEdit());
                            await client.SendTextMessageAsync(BotUser.IdToChange, $"Ваше имя изменили на {message.Text}");
                        }
                        await dataBase.SaveChangesAsync();
                    }
                    BotUser.IdToChange = null;
                    BotUser.NameChanging = false;
                }

                else if (message.Text == "Im Matvey")
                {
                    await client.SendTextMessageAsync(message.Chat.Id,
                        "Выберите предмет для редактирования:",
                        replyMarkup: Buttons.SubjectsEdit());
                }
                //Эта зона в конце ифов, все сабстринги располагать в порядке возрастания длинны подстроки
                else if (message.Text.Substring(0, 11) == "Регистрация")
                {
                    Console.WriteLine(Convert.ToString(message.Chat.Id));
                    using (ApplicationContext dataBase = new ApplicationContext())
                    {
                        var users = dataBase.BotUsers.ToList();
                        var selectedBotUser = from user in users
                                              where user.Id == Convert.ToString(message.Chat.Id)
                                              select user;

                        if (!selectedBotUser.Any())
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Вы зарегистрированы");
                            BotUser newUser = new BotUser { Id = Convert.ToString(message.Chat.Id), Name = message.Text.Substring(12) };
                            dataBase.Add(newUser);
                            await dataBase.SaveChangesAsync();
                        }
                        else
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, "Такой пользователь уже зарегистрирован");
                        }
                    }
                }


            }
            catch
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Я так не умею");
            }
        }
    }
}
