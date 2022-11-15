using Telegram.Bot.Types;

namespace UsefulLinksDuringWarUa.Services
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}