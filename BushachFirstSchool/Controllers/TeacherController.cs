using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Concrate;


namespace BushachFirstSchool.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherController( ISchoolRepositorycs repository) 
        {
            _repository = repository;
        }
 
        // GET: /Teacher/
        public ActionResult Index()
        {
            return View(_repository.Teachers);
        }
        public ActionResult Create()
        {
            return View(new Teacher());
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher  )
        {
            if (ModelState.IsValid)
            {
              //  var upload = Request.Files["Photo"];
                if (teacher.PhotoBytes != null)
                {
                    teacher.Foto = new Foto();
                    teacher.Foto.Content = teacher.PhotoBytes.InputStream.ToArray();                   
                }
                _repository.SaveTeacher(teacher);
                TempData["message"] = teacher.Surname + " " + teacher.Name + " успішно зареєстрований(на).";
                return View("Index",_repository.Teachers);
            }
            else
            {
                return View(teacher);
            }
        }
        private  ISchoolRepositorycs _repository ;

    }
}
