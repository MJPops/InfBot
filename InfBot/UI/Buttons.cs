using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace InfBot.UI
{
    class Buttons
    {
        public static IReplyMarkup Start()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Предметы", callbackData: "Предметы")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Расписание", callbackData: "Расписание")
                    }
            });
            ;
        }
        public static IReplyMarkup Subjects()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Диффуры", callbackData: "Диффуры"),//id-1
                        InlineKeyboardButton.WithCallbackData(text: "Физика", callbackData: "Физика")//id-2
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "МСОПР", callbackData: "МСОПР"),//id-3
                        InlineKeyboardButton.WithCallbackData(text: "Физ-ра", callbackData: "Физ-ра")//id-4
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТОИ", callbackData: "ТОИ"),//id-5
                        InlineKeyboardButton.WithCallbackData(text: "Социология", callbackData: "Социология")//id-6
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Философия", callbackData: "Философия"),//id-7
                        InlineKeyboardButton.WithCallbackData(text: "Программирование", callbackData: "Программирование")//id-8
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТВИМС", callbackData: "ТВИМС"),//id-9
                        InlineKeyboardButton.WithCallbackData(text: "ИнЯз", callbackData: "ИнЯз")//id-10
                    }
            });
            ;
        }
        public static IReplyMarkup InSubject(string link)
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Домашка", callbackData: "Домашка")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithUrl(text: "Расписание", url: link)
                    }
            });
            ;
        }

        public static IReplyMarkup SubjectsEdit()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Диффуры", callbackData: "ДиффурыEdit"),
                        InlineKeyboardButton.WithCallbackData(text: "Физ-ра", callbackData: "ФизикаEdit")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "МСОПР", callbackData: "МСОПРEdit"),
                        InlineKeyboardButton.WithCallbackData(text: "Физ-ра", callbackData: "Физ-раEdit")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТОИ", callbackData: "ТОИEdit"),
                        InlineKeyboardButton.WithCallbackData(text: "Социология", callbackData: "СоциологияEdit")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Философия", callbackData: "ФилософияEdit"),
                        InlineKeyboardButton.WithCallbackData(text: "Программирование", callbackData: "ПрограммированиеEdit")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТВИМС", callbackData: "ТВИМС"),
                        InlineKeyboardButton.WithCallbackData(text: "ИнЯз", callbackData: "ИнЯз")
                    }
            });
            ;
        }
        public static IReplyMarkup InSubjectEdit()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
            {
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Домашку", callbackData: "Домашку"),
                        InlineKeyboardButton.WithCallbackData(text: "Материалы", callbackData: "Материалы")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "<<Назад", callbackData: "I'm Matvey")
                    }
            });
            ;
        }
    }
}
