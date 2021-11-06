namespace InfBot.Models
{
    public class Subject
    {
        public static string parametrSetingStatus = null;
        public static string subjectToChange = null;

        public string Id { get; set; }
        public string Name { get; set; }
        public string HomeWork { get; set; }
        public string Link { get; set; }

        public Subject()
        {
            Name = null;
            HomeWork = null;
            Link = null;
        }
    }
}
