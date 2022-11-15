using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class PsychologicalHelpCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;

        public override UrlLink[] urls => new UrlLink[]
        {
            new UrlLink("https://t.me/israeltoday/4073",
                "Список ізраїльских російськомовних психотерапевтів, готових надати безкоштовну психологічну допомогу жителям України"),
            new UrlLink("https://www.instagram.com/p/CabqAmkJIZu/", "Пропозиція безкоштовної психологічної допомоги"),
            new UrlLink("https://t.me/pavlushaiyava", "Аудіокнижки для дітей"),
            new UrlLink("http://likar.support/", "Безкоштовні zoom-консультації від лікарів"),
            new UrlLink("tellme.com.ua", "Безкоштовні психологічні консультації."),
            new UrlLink("@yak_ty_bot", "Колективна психологічна онлайн-підтримки в Telegram - @yak_ty_bot"),
            new UrlLink("@vartozhyty", "Безкоштовна психологічна допомога в умовах війни - @vartozhyty"),
        };

        public PsychologicalHelpCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.PsychologicalHelpCommand;

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