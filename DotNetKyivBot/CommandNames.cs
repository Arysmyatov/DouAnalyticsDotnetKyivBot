
namespace UsefulLinksDuringWarUa
{
    public class CommandNames
    {
        public const string StartCommand = "/start";
        public const string InformationSourcesCommand = "Джерела Інформації";
        public const string OnlineMapsCommand = "Онлайн карти";
        public const string EvacuationCommand = "Евакуація";
        public const string HowToHelpCommand = "Як допомогти";
        public const string HowToSupportCommand = "Як підтримати";
        public const string PsychologicalHelpCommand = "Психологична допомога";

        public static string[] GetCommandNames => new[]
        {
            StartCommand,
            InformationSourcesCommand,
            OnlineMapsCommand,
            EvacuationCommand,
            HowToHelpCommand,
            HowToSupportCommand,
            PsychologicalHelpCommand
        };
    }
}