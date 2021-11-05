﻿using System.Collections.Generic;
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
                        InlineKeyboardButton.WithCallbackData(text: "Диффуры", callbackData: "Диффуры"),
                        InlineKeyboardButton.WithCallbackData(text: "Физ-ра", callbackData: "Физика")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "МСОПР", callbackData: "МСОПР"),
                        InlineKeyboardButton.WithCallbackData(text: "Физ-ра", callbackData: "Физ-ра")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТОИ", callbackData: "ТОИ"),
                        InlineKeyboardButton.WithCallbackData(text: "Социология", callbackData: "Социология")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "Философия", callbackData: "Философия"),
                        InlineKeyboardButton.WithCallbackData(text: "Программирование", callbackData: "Программирование")
                    },
                    new List<InlineKeyboardButton>
                    {
                        InlineKeyboardButton.WithCallbackData(text: "ТВИМС", callbackData: "ТВИМС"),
                        InlineKeyboardButton.WithCallbackData(text: "ИнЯз", callbackData: "ИнЯз")
                    }
            });
            ;
        }
    }
}
