using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Models;
using BushachFirstSchool.Domain.Entity;

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
