using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;
        public override UrlLink[] urls => null;

        public StartCommand(
            TelegramBot telegramBot,
            IUserService userService,
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = userService.GetOrCreate(update);
            var inlineKeyboard = buildMarkupByButtons.GetMarkups();

            var textMessage = "Vacancy Analytics form developers.org.ua for .NET Kyiv \n \n" +
                                   "Джерело: dou.ua";

            await botClient.SendTextMessageAsync(
                user.ChatId, textMessage,
                ParseMode.Markdown,
                replyMarkup: inlineKeyboard);
        }
    }
}