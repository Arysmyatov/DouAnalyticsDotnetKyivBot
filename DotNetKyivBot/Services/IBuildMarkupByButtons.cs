using Telegram.Bot.Types.ReplyMarkups;

namespace UsefulLinksDuringWarUa.Services;

public interface IBuildMarkupByButtons
{
    public ReplyKeyboardMarkup GetMarkups();
}