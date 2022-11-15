using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class InformationSourcesCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;
        public override UrlLink[] urls => new UrlLink[]
        {
            new UrlLink("https://www.facebook.com/CinCAFU", "Головнокомандувач ЗС України / CinC AF of Ukraine"),
            new UrlLink("https://www.facebook.com/GeneralStaff.ua", "Генеральний штаб ЗСУ / General Staff of the Armed Forces of Ukraine"),
            new UrlLink("https://www.facebook.com/verkhovna.rada.ukraine", "Верховна Рада України"),
            new UrlLink("https://www.facebook.com/DPSUkraine", "Державна прикордонна служба"),
            new UrlLink("https://www.facebook.com/MNS.GOV.UA", "Державна служба надзвичайних ситуацій (ДСНС)"),
            new UrlLink("https://www.facebook.com/StratcomCentreUA", "Центр стратегічних комунікацій та інформаційної безпеки"),
            new UrlLink("https://www.facebook.com/dsszzi", "Державна служба спеціального зв’язку та захисту інформації України"),
            new UrlLink("https://www.facebook.com/navy.mil.gov.ua", "Військово-морські сили ЗСУ"),
            new UrlLink("https://www.facebook.com/TerritorialDefenseForces", "Територіальна оборона ЗСУ"),
            new UrlLink("https://www.facebook.com/pressjfo.news?__cft__%5B0%5D=AZX0m5aSAIWuYRGho28htd42P5FC9972GpmRbMEOoAhR0-WKfMzvSjFInhAHGlWRXdsR0-N8CZqeFmH6uMQDtiG1yQ8KV5CSMsBtvXIlVdg8Wa4tof5x-JidC6YfRTHLloArlrEPdVN5x5olc3RSHJua&__tn__=-%5DK-R", "Операція об’єднаних сил / Joint Forces Operation"),
            new UrlLink("https://www.facebook.com/JointForcesCommandAFU/?__cft__%5B0%5D=AZX0m5aSAIWuYRGho28htd42P5FC9972GpmRbMEOoAhR0-WKfMzvSjFInhAHGlWRXdsR0-N8CZqeFmH6uMQDtiG1yQ8KV5CSMsBtvXIlVdg8Wa4tof5x-JidC6YfRTHLloArlrEPdVN5x5olc3RSHJua&__tn__=kK-R", "Командування об’єднаних сил ЗС України"),
            new UrlLink("https://www.facebook.com/rnbou", "Рада національної безпеки і оборони України"),
            new UrlLink("https://www.facebook.com/iamo.armyinform/?__cft__%5B0%5D=AZX0m5aSAIWuYRGho28htd42P5FC9972GpmRbMEOoAhR0-WKfMzvSjFInhAHGlWRXdsR0-N8CZqeFmH6uMQDtiG1yQ8KV5CSMsBtvXIlVdg8Wa4tof5x-JidC6YfRTHLloArlrEPdVN5x5olc3RSHJua&__tn__=kK-R", "Інформагентство АрміяInform"),
            new UrlLink("https://www.youtube.com/watch?v=dXHLym5kio8", "Суспільне мовлення"),
            new UrlLink("https://www.radiosvoboda.org/a/putin-oholosyv-viynu-operatyvno/31719784.html", "Радіо Свобода"),
            new UrlLink("https://www.bbc.com/ukrainian/live/news-60462319", "BBC Ukraine"),
            new UrlLink("https://viyna.net/", "Пошук інформації під час війни."),
            new UrlLink("https://sharethetruths.org/category/daily-updates/", "Перевірена інформація різними мовами для іноземних друзів"),
            new UrlLink("@frontier.in.ukraine", "Інформація / новини англійською моою"),
        };

        public InformationSourcesCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.InformationSourcesCommand;

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