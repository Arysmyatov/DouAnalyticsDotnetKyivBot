using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UsefulLinksDuringWarUa.Entities;

namespace UsefulLinksDuringWarUa.Services
{
    public class UserService : IUserService
    {
        public AppUser GetOrCreate(Update update)
        {
            var user = update.Type switch
            {
                UpdateType.CallbackQuery => new AppUser
                {
                    Username = update.CallbackQuery.From.Username,
                    ChatId = update.CallbackQuery.Message.Chat.Id,
                    FirstName = update.CallbackQuery.Message.From.FirstName,
                    LastName = update.CallbackQuery.Message.From.LastName
                },
                UpdateType.Message => new AppUser
                {
                    Username = update.Message.Chat.Username,
                    ChatId = update.Message.Chat.Id,
                    FirstName = update.Message.Chat.FirstName,
                    LastName = update.Message.Chat.LastName
                }
            };

            return user;
        }
    }
}