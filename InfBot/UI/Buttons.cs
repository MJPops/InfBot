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
    }
}
