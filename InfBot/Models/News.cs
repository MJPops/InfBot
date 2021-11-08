using System.ComponentModel.DataAnnotations;

namespace HelloApp
{
    public class News
    {
        public static bool ToChange = false;
        public static string IdToChange = null;

        [Key]
        public string DateAndTime { get; set; }
        public string Novelty { get; set; }
    }
}