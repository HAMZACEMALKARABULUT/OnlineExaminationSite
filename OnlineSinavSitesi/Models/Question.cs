using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSinavSitesi.Models
{
    public class Question
    {
        
        public int Id { get; set; }

        public int No { get; set; }
        
        public string Text { get; set; }

        public string Description { get; set; }

        public bool isOptional { get; set; }

        public string TextAnswer { get; set; }

        public Image Image { get; set; }

        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public Exam Exam { get; set; }

        public List<Option> Options { get; set; }


    }
}
