using System.Text;
using Telegram.Bot.Types;
using UsefulLinksDuringWarUa.Entities;

namespace UsefulLinksDuringWarUa.Commands
{
    public abstract class BaseCommand
    {
        public abstract string Name { get; }
        public abstract Task ExecuteAsync(Update update);
        public abstract UrlLink[] urls { get; }

        public string GetMessage()
        {
            var stringResult = new StringBuilder();

            foreach (var urlLink in urls)
            {
                stringResult.Append(urlLink.BuildHtmlString());
                stringResult.Append("\n");
                stringResult.Append("\n");
            }
            return stringResult.ToString();
        }
    }
}