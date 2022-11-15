using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class OnlineMapsCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;
        public override UrlLink[] urls => new UrlLink[]
        {
            new UrlLink("https://opir.org","Онлайн-карта найближчих магазинів, аптек, АЗС, укриття тощо"),
            new UrlLink("https://www.google.com/maps/d/u/0/viewer?mid=1IDomXCMpdCFHI-Xe7fuGQlOD2_s6lS8C&hl=uk&ll=50.447656209688795%2C30.51202355&z=11", "Гуманітарні штаби Києва"),
            new UrlLink("https://dou.ua/forums/topic/36789/", "Онлайн-карта безкоштовного житла у Польщі та Європі"),
            new UrlLink("https://www.ukraineshelter.com/en/", "Пошук житла за кордоном"),
            new UrlLink("https://www.mapotic.com/ukraine-border-crossings", "On-line черга на кордоні")
        };

        public OnlineMapsCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.OnlineMapsCommand;

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