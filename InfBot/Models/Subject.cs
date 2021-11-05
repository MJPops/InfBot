using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfBot.Models
{
    public class Subject
    {
        public static string parametrSetingStatus = null;
        public static string subjectToChange = null;

        public string Id { get; set; }
        public string Name { get; set; }
        public string HomeWork { get; set; }
        public string SubjectLink { get; set; }

        public Subject()
        {
            Name = null;
            HomeWork = null;
            SubjectLink = null;
        }
    }
}
