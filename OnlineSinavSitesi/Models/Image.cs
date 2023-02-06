using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSinavSitesi.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string ImgType { get; set; }

        public string FileName { get; set; } 

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        
        [NotMapped]
        public List<IFormFile> ImgFile { get; set; }
    }
}