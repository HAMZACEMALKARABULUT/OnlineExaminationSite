using System.Net.Mail;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace OnlineSinavSitesi.Models
{

    public class Mail
    {

        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
       
        public string Subject { get; set; }

        public string Message { get; set; }
        public string ClientAdress { get; set; }


        public string ReceiverAdress { get; set; }

        public string SenderAdress { get; set; }

    }

}
