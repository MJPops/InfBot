using System.ComponentModel.DataAnnotations;

namespace HelloApp
{
    public class News
    {
        [Key]
        public string DateAndTime { get; set; }
        public string Novelty { get; set; }
    }
}