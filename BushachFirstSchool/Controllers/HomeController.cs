using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Models;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Infrastructure;

namespace BushachFirstSchool.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ISchoolRepositorycs repository) 
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Teacher = _repository.Teachers.OrderBy(r => Guid.NewGuid()).Take(CountTeacherPerPage).ToList(),
                News = _repository.Newses.OrderBy(r => Guid.NewGuid()).Take(CountNewsPerPage).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public JsonResult SendMessage( MailModel model )
        {
            try
            {
               EmailSender.EmailSend(model); 
            }
            catch (Exception e)
            {
                return Json(new { message = "Сталася помилка під час відправлення: " + e.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { message = "Ваше повідомлення відправленно. Його буде розглянуто на протязі кількох днів. Хорошого вам дня."}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       private  ISchoolRepositorycs _repository ;
       private readonly Int32 CountTeacherPerPage = 10;
       private readonly Int32 CountNewsPerPage = 5;
    }
}
