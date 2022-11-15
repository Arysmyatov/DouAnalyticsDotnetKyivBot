using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;
using UsefulLinksDuringWarUa.Services;

namespace UsefulLinksDuringWarUa.Commands
{
    public class EvacuationCommand : BaseCommand
    {
        private readonly IUserService userService;
        private readonly TelegramBotClient botClient;
        private readonly IBuildMarkupByButtons buildMarkupByButtons;

        public override UrlLink[] urls => new UrlLink[]
        {
            new UrlLink("https://www.ukrainenow.org/looking-for-help-abroad",
                "UkraineNow: Пошук трансфера і житла закордоном"),
            new UrlLink(
                "https://www.ukraineshelter.com/en/?utm_medium=mailpromo&utm_source=directmail&utm_content=pidtrymka&utm_campaign=dnepropetr",
                "Знайти/запропонувати житло"),
            new UrlLink("www.host4ukraine.com", "Житло за кордоном"),
            new UrlLink("www.shelter4ua.com", "Пошук житла за кордоном"),
            new UrlLink("@nampodorozi_bot",
                "ПБот в Telegram, який зможе допомогти знайти попутника - @nampodorozi_bot"),
            new UrlLink("https://dou.ua/forums/topic/36832/", "Сайт із пошуку безкоштовного притулку в Європі"),
            new UrlLink("https://t.me/pomoc2022", "Вивіз громадян з України"),
            new UrlLink("@nampodorozi_bot", "Бот для пошуку попутників — @nampodorozi_bot"),
            new UrlLink("https://bit.ly/3swKRuJ", "Моніторинг стану черг на кордонах з країнами"),
            new UrlLink("https://t.me/+SvJO-CAYnH04MTgx",
                "Лінгво-волонтери  — перекладачі, які допомагають біженцям перекладати документи та комунікувати під час виїзду за кордон"),
            new UrlLink("https://t.me/UkrzalInfo", "Інформація про евакуаційні потяги"),
            new UrlLink("https://docs.google.com/document/d/1ebXPKnF_krrfkpjF4dHKhJ3YYzYVpg8w-JAG91yLxdc/edit",
                "Relocation Options for Ukrainians"),
            new UrlLink("@safe_space_ua_bot", "Список укриттів в Києві — @safe_space_ua_bot"),
            new UrlLink("https://zaborona.com/yak-organizuvaty-ukryttya-vdoma-instrukcziya-zaborony/",
                "Повний гайд, як організувати укриття вдома"),
            new UrlLink("https://bit.ly/35kDDkz", "Повітряна тривога - Google Play"),
            new UrlLink("https://apple.co/3K6v9fD", "Повітряна тривога - App Store"),

            new UrlLink("@dogs_adopt_kiev",
                "Притулок для тварин, чиї господарі зараз не можуть про них піклуватися - @dogs_adopt_kiev"),
            new UrlLink("https://ec.europa.eu/info/strategy/priorities-2019-2024/stronger-europe-world/eu-solidarity-ukraine/eu-assistance-ukraine/information-people-fleeing-war-ukraine_uk",
                "Офіційна інформація про права українських біженців у ЄС", ", підготовку до виїзду та подальші пересування в межах країн Європейського союзу.")
        };

        public EvacuationCommand(
            IUserService userService, 
            TelegramBot telegramBot, 
            IBuildMarkupByButtons buildMarkupByButtons)
        {
            this.userService = userService;
            botClient = telegramBot.GetBot().Result;
            this.buildMarkupByButtons = buildMarkupByButtons;
        }

        public override string Name => CommandNames.EvacuationCommand;

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