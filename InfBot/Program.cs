using HelloApp;
using InfBot.Models;
using InfBot.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

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

            static async Task SubjectsWithLinksAsync(Subject subject, Message message)
            {
                try
                {
                    await client.EditMessageTextAsync(message.Chat.Id,
                        message.MessageId,
                        $"{subject.Name} Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                        replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                        Buttons.InSubject(subject.Link, subject.LinkToLesson));

                }
                catch
                {
                    try
                    {
                        await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"{subject.Name} Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                            Buttons.InSubject(subject.Link));

                    }
                    catch
                    {
                        try
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                message.MessageId,
                                $"{subject.Name} Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)
                                Buttons.InSubject(subject.LinkToLesson));

                        }
                        catch
                        {
                            await client.EditMessageTextAsync(message.Chat.Id,
                                    message.MessageId,
                                    $"{subject.Name} Д/З:\n\n▫ {subject.HomeWork ?? "Д/З нет"}",
                                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubject());
                        }
                    }
                }
            }
            static async Task SubjectEddit(Subject subject, Message message)
            {
                await client.EditMessageTextAsync(message.Chat.Id,
                            message.MessageId,
                            $"{subject.Name}:\n\n▫ {subject.HomeWork ?? "Д/З нет"}\n\n" +
                            $"▫ Ссылка: {subject.Link ?? "Ссылки нет"}\n\n" +
                            $"Что вы хотите изменить?",
                            replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.InSubjectEdit());
            }


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

            else if (e.CallbackQuery.Data == "Im Matvey")
            {
                await client.EditMessageTextAsync(message.Chat.Id,
                    message.MessageId,
                    "Выберите предмет для редактирования:",
                    replyMarkup: (Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup)Buttons.SubjectsEdit());
                Subject.subjectToChange = null;
                BotUser.Maling = false;
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
            else
            {
                using (ApplicationContext dataBase = new ApplicationContext())
                {
                    if (dataBase.Subjects.ToList().Any())
                    {
                        var selectedSubjects = dataBase.Subjects.ToList();
                        if (e.CallbackQuery.Data == "Диффуры")
                        {
                            var subject = await dataBase.Subjects.FindAsync("1");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "Физика")
                        {
                            var subject = await dataBase.Subjects.FindAsync("2");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "МСОПР")
                        {
                            var subject = await dataBase.Subjects.FindAsync("3");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "Физ-ра")
                        {
                            var subject = await dataBase.Subjects.FindAsync("4");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "ТОИ")
                        {
                            var subject = await dataBase.Subjects.FindAsync("5");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "Социология")
                        {
                            var subject = await dataBase.Subjects.FindAsync("6");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "Философия")
                        {
                            var subject = await dataBase.Subjects.FindAsync("7");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "Программирование")
                        {
                            var subject = await dataBase.Subjects.FindAsync("8");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "ТВИМС")
                        {
                            var subject = await dataBase.Subjects.FindAsync("9");
                            await SubjectsWithLinksAsync(subject, message);
                        }
                        else if (e.CallbackQuery.Data == "ИнЯз")
                        {
                            var subject = await dataBase.Subjects.FindAsync("10");
                            await SubjectsWithLinksAsync(subject, message);
                        }

                        else if (e.CallbackQuery.Data == "ДиффурыEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("1");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "1";
                        }
                        else if (e.CallbackQuery.Data == "ФизикаEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("2");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "2";
                        }
                        else if (e.CallbackQuery.Data == "Физ-раEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("3");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "3";
                        }
                        else if (e.CallbackQuery.Data == "ТОИEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("4");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "4";
                        }
                        else if (e.CallbackQuery.Data == "ФилософияEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("5");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "5";
                        }
                        else if (e.CallbackQuery.Data == "СоциологияEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("6");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "6";
                        }
                        else if (e.CallbackQuery.Data == "ПрограммированиеEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("7");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "7";
                        }
                        else if (e.CallbackQuery.Data == "МСОПРEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("8");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "8";
                        }
                        else if (e.CallbackQuery.Data == "ТВИМСEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("9");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "9";
                        }
                        else if (e.CallbackQuery.Data == "ИнЯзEdit")
                        {
                            var subject = await dataBase.Subjects.FindAsync("10");
                            await SubjectEddit(subject, message);
                            Subject.subjectToChange = "10";
                        }
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Маслину поймал, предмета нету");
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
                            BotUser newUser = new BotUser { Id = Convert.ToString(message.Chat.Id), Name = message.Text.Substring(12) };
                            await client.SendTextMessageAsync(message.Chat.Id, "Вы зарегистрированы");
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
