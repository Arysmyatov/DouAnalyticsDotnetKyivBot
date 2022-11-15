using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class HowToHelpCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;

        public override UrlLink[] urls => new []
        {
            new UrlLink(
                "https://how-to-help-ukraine-now.super.site/donate?utm_source=directmail&utm_medium=mailpromo&utm_campaign=dnepropetr&utm_content=pidtrymka",
                "Стати донором"),
            new UrlLink(
                "https://t.me/itarmyofukraine2022?utm_source=directmail&utm_medium=mailpromo&utm_campaign=dnepropetr&utm_content=pidtrymka",
                "IT ARMY of Ukraine"),
            new UrlLink("https://v-tylu.work/", "Біржа волонтерських робіт"),
            new UrlLink("https://t.me/VolunteerCountry", "Волонтерський тг-канал"),
            new UrlLink("https://t.me/VolunteerTalks", "Всеукраїнський канал"),
            new UrlLink("@stop_russian_war_bot",
                "Помітили російські війська та техніку? Повідомте про це негайно! Створено офіційний чат-бот — @stop_russian_war_bot")
        };

        public HowToHelpCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.HowToHelpCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = userService.GetOrCreate(update);
            var inlineKeyboard = buildMarkupByButtons.GetMarkups();

            var textMessage = GetMessage();
            
            await botClient.SendTextMessageAsync(user.ChatId, textMessage, ParseMode.Html,
                replyMarkup: inlineKeyboard);
        }
    }
}