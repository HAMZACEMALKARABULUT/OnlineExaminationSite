using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSinavSitesi.Models
{
    public class Option
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool isCorrect{ get; set; }

        public bool isSelected { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; } 

        public int QuestionId { get; set; }

        //public string Name { get; set; }
    }
}