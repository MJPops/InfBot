namespace InfBot.Models
{
    public class BotUser
    {
        public static bool Maling = false;
        public static bool NameChanging = false;
        public static string IdToChange = null;

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
