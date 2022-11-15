using Telegram.Bot.Types.ReplyMarkups;

namespace UsefulLinksDuringWarUa.Services;

public class BuildMarkupByButtons : IBuildMarkupByButtons
{
    public ReplyKeyboardMarkup GetMarkups()
    {
        var keyboards = new List<List<KeyboardButton>>();
        var keyboardButtonRow = new List<KeyboardButton>();
        var columnNumber = 0;
        var itemsNumber = 0;
        
        foreach (var commandName in CommandNames.GetCommandNames)
        {
            if (commandName == CommandNames.StartCommand) continue;
            keyboardButtonRow.Add(new KeyboardButton(commandName));
            itemsNumber++;
            if (columnNumber == 1 ||
                itemsNumber == CommandNames.GetCommandNames.Length - 1)
            {
                keyboards.Add(keyboardButtonRow);
                columnNumber = 0;
                keyboardButtonRow = new List<KeyboardButton>();
                continue;
            }

            columnNumber++;
        }

        return new ReplyKeyboardMarkup(keyboards);
    }
}