using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class HowToSupportCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;

        public override UrlLink[] urls => new[]
        {
            new UrlLink(
                "https://how-to-help-ukraine-now.super.site/donate?utm_source=directmail&utm_medium=mailpromo&utm_campaign=dnepropetr&utm_content=pidtrymka",
                "Сайт збору коштів для іноземців"),
            new UrlLink(
                "https://moz.gov.ua/article/news/moz-ta-chervonij-hrest-vidkrivajut-rahunok-dlja-dopomogi-medikam?utm_source=directmail&utm_medium=mailpromo&utm_campaign=dnepropetr&utm_content=pidtrymka",
                "Збір коштів для Червоного Хреста"),
            new UrlLink("https://savelife.in.ua/donate/", "«Повернись живим»"),
            new UrlLink(
                "https://bank.gov.ua/en/news/all/natsionalniy-bank-vidkriv-spetsrahunok-dlya-zboru-koshtiv-na-potrebi-armiyi",
                "Офіційний рахунок НБУ для підтримки ЗСУ"),
            new UrlLink("https://armysos.com.ua/pomoch-armii", "Армія SOS : закупівля амуніції"),
            new UrlLink("https://www.facebook.com/hospitallers/", "Медичний батальйон «Госпітальєри»"),
            new UrlLink("https://www.portmone.com.ua/r3/uk/terminal/index/index/id/118103/",
                "Переказати кошти з ЄПідтримка на армію"),
            new UrlLink("http://uahelp.monobank.ua/", "Посилання для допомоги Українській Армії від monobank")
        };

        public HowToSupportCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.HowToSupportCommand;

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