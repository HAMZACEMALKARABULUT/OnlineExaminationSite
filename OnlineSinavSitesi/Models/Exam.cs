using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace OnlineSinavSitesi.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public string LessonName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime Date { get; set; }
       
        public int Time { get; set; }
     
        //sınavın oluşturucusu var
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public int CreatorId { get; set; }

        //sınavın katıımcıları var
        public List<ExamUser> Participants { get; set; }

        //sınavın soruları var
        public List<Question> Questions { get; set; }

    }
}

