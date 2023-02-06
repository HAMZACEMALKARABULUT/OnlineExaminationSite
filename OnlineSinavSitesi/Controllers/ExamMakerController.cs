using Microsoft.AspNetCore.Mvc;
using OnlineSinavSitesi.Models;



using System.Text.Json;

using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace OnlineSinavSitesi.Controllers
{
    public class ExamMakerController : Controller
    {

        private readonly SinavContext _context;
        public ExamMakerController(SinavContext context)
        {
            _context = context;
        }// 

        public IActionResult CreateExam(Exam exam)
        {
           

            _context.Exams.Add(exam);
            _context.SaveChanges();

            var createdExam = _context.Exams.Where(x => x.LessonName == exam.LessonName && x.CreatorId 
            
            == exam.CreatorId && x.CreatedDate == exam.CreatedDate && x.Date == exam.Date).FirstOrDefault();


            HttpContext.Session.SetInt32("examId", exam.Id);

            return RedirectToAction("CreateQuestion");
            
        }
         

        public ViewResult CreateQuestion()
        {
            return View(HttpContext.Session.GetInt32("examId"));
        }
        
        [HttpPost]
        public IActionResult CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return View();
        }




        public IActionResult AddExamInfo()
        {
            var appUserJson = HttpContext.Session.GetString("user");

            var appUser = JsonSerializer.Deserialize<User>(appUserJson);
            return View(appUser);

        }

        

        public IActionResult PrepareQuestion()
        {



            return View();

            
            

        }

    }  }
                    
