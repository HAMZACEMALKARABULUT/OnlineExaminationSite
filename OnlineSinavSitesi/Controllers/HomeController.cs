using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineSinavSitesi.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OnlineSinavSitesi.Controllers
{
    
   
    public class HomeController : Controller
    {
         //entity framework nesnesi
         private SinavContext _context;
       public HomeController(SinavContext context)
        {


            _context = context;
        }



        public string receiverMail = "hamzacml456@gmail.com";//To address 
        public string senderMail = "hmzcmlkrblt@gmail.com";//From address SS


        //kullanıcının sisteme mail attığı kısım
        [HttpPost]
        public IActionResult MailGonder(Mail mail)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.Subject = mail.Subject;
               
                msg.From = new MailAddress(senderMail, mail.FullName);
                msg.To.Add(new MailAddress(receiverMail, "Online Sınav Sitesi"));
                msg.Body = mail.Message +"  " + mail.ClientAdress;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                // Host ve Port Gereklidir!
                SmtpClient smtp = new SmtpClient("smtp-relay.sendinblue.com",587);
                // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
                NetworkCredential AccountInfo = new NetworkCredential(senderMail,"0dxm65A2vW1cwK4X");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = AccountInfo;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(msg);
                MailMessage message = new MailMessage(senderMail, receiverMail);
                ViewBag.isim = "Mesajınız Gönderildi.";
                return View();
            }

            catch(Exception ex) { throw ex; }
        }
            
        
        public IActionResult Index()
        {
            return View();
        }
        //Kayıt sayfasına yönlendiren controller
        public IActionResult RegisterAndLogIn()
        {
            return View();
        }

        //Kayıt işlemini yapan controller
        public IActionResult Register(User user)
        {
            //kayıt işlemi yapan kullanıcının maili sistemde kayıtlı mı kontrolü yapılıyor
            var sameUser = _context.Users.Where(x => x.Mail == user.Mail).FirstOrDefault();

            
            if(user != null && sameUser == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                ViewBag.isSucces = "kayıt başarılı";
            }
            else
                ViewBag.isSucces = "kayıt başarısız!";


            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}