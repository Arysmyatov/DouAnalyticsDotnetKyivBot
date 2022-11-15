using Telegram.Bot.Types;
using UsefulLinksDuringWarUa.Entities;

namespace UsefulLinksDuringWarUa.Services
{
    public interface IUserService
    {
        AppUser GetOrCreate(Update update);
    }
}