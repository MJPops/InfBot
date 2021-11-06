using HelloApp;
using System.Linq;
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
        public string Link { get; set; }
        public string LinkToLesson { get; set; }

        public Subject()
        {
            HomeWork = null;
        }

        public static async Task AddStandartSubjectsAsync()
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {
                var selectedSubjects = dataBase.Subjects.ToList();
                if (!selectedSubjects.Any())
                {
                    dataBase.Add(new Subject { Id = "1",
                        Name = "Диффуры", 
                        Link= "https://drive.google.com/drive/folders/1vSO2MlPGUIivAF6qGmOMTCirJPIZ018i?usp=sharing",
                        LinkToLesson= "https://lms.mai.ru/course/view.php?id=4018" });
                    dataBase.Add(new Subject { Id = "2", 
                        Name = "Физика",
                        Link = "https://drive.google.com/drive/folders/1-2HlKBwkQpC_OQ4EEa8ZhS_cYyq3ZV3u?usp=sharing", 
                        LinkToLesson = "https://lms.mai.ru/course/view.php?id=5609"
                    });
                    dataBase.Add(new Subject { Id = "3",
                        Name = "МСОПР",
                        Link = "https://drive.google.com/drive/folders/1-HRsNpArWQ7oWaIneIKzP9fwvP2VHVKr?usp=sharing", 
                        LinkToLesson = "https://lms.mai.ru/course/view.php?id=4895"
                    });
                    dataBase.Add(new Subject { Id = "4",
                        Name = "Физ-ра", 
                        Link = "https://drive.google.com/drive/folders/1-PhVWD8ZXhoy8n3Z016V8oiUqXGFo6ut?usp=sharing",
                        LinkToLesson = "https://lms.mai.ru/course/view.php?id=6537"
                    });
                    dataBase.Add(new Subject { Id = "5", 
                        Name = "ТОИ", 
                        Link = "https://drive.google.com/drive/folders/1-JAbRF-1lpNcJRrDOjnLJb_FMJb8dKlo?usp=sharing",
                        LinkToLesson = "https://t.me/toi609"
                    });
                    dataBase.Add(new Subject { Id = "6",
                        Name = "Социология",
                        Link = "https://drive.google.com/drive/folders/1-FZsLCQ6RolnOuwjnP-oYI15F-6IV2E4?usp=sharing",
                        LinkToLesson = "https://lms.mai.ru/course/view.php?id=4281"
                    });
                    dataBase.Add(new Subject { Id = "7",
                        Name = "Философия",
                        Link = "https://drive.google.com/drive/folders/1-Dwyw6G5S3D21ed39jBrgFpMWA50rkWs?usp=sharing", 
                        LinkToLesson = "https://vk.com/away.php?to=https%3A%2F%2Fus02web.zoom.us%2Fj%2F6279497630%3Fpwd%3DUndkbDZuZmgzQ3dkZng"
                    });
                    dataBase.Add(new Subject { Id = "8",
                        Name = "Программирование", 
                        Link = "https://drive.google.com/drive/folders/1-FyMosbIYiBVlQGgh0b40fPIpyHPZlKy?usp=sharing", 
                        LinkToLesson = "https://lms.mai.ru/course/view.php?id=9985"
                    });
                    dataBase.Add(new Subject { Id = "9",
                        Name = "ТВИМС", Link = "https://drive.google.com/drive/folders/1-MfpODBMAqHYTiWnPPlz0lGviMpDRk3s?usp=sharing",
                        LinkToLesson = "https://vk.com/away.php?to=https%3A%2F%2Fus05web.zoom.us%2Fj%2F3682978917%3Fpwd%3DS2VYek5EME" +
                        "U2TDUwSTZORVBXU0dXUT09"
                    });
                    dataBase.Add(new Subject { Id = "10",
                        Name = "ИнЯз", Link = "https://drive.google.com/drive/folders/1-96EGKSlx3G1v3v3y1ol0Ila9Ca0a6bB?usp=sharing",
                        LinkToLesson = "https://vk.com/away.php?to=https%3A%2F%2Fus04web.zoom.us%2Fj%2F4652845545%3Fpwd%3DUXIxY0x6b" +
                        "UpteHVMN3M3Y1o4YVVLZz09"
                    });
                    await dataBase.SaveChangesAsync();
                }
            }
        }
    }
}
