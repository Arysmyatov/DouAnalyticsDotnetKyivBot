using Telegram.Bot.Types;
using UsefulLinksDuringWarUa.Commands;

namespace UsefulLinksDuringWarUa.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<BaseCommand> _commands;
        private BaseCommand _lastCommand;

        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }
        
        public async Task Execute(Update update)
        {
            if(update?.Message?.Chat == null && update?.CallbackQuery == null)
                return;

            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }

            if (update.Message != null)
            {
                await ExecuteCommand(update.Message.Text, update);
            }
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.FirstOrDefault(x => x.Name.Contains(commandName, StringComparison.InvariantCultureIgnoreCase));
            if(_lastCommand == null) return;
            
            await _lastCommand.ExecuteAsync(update);
        }
    }
}