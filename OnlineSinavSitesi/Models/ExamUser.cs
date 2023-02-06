using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSinavSitesi.Models
{
    //ara tablo
    //bir sınavın birden fazla katılımcı user'ı olabilir
    //bir user'ın birden fazla sınavı olabilir
    public class ExamUser
    {
        [ForeignKey(nameof(User))]
        public int UId { get; set; }

        [ForeignKey(nameof(Exam))]
        public int EId { get; set; }

        public User User { get; set; }

        public Exam Exam { get; set; }
    }
}