using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Concrate;
using BushachFirstSchool.Models;


namespace BushachFirstSchool.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherController( ISchoolRepositorycs repository) 
        {
            _repository = repository;
        }
 
        // GET: /Teacher/
        public ActionResult Index(Int32 Page = 1)
        {
            return View(getPagingInfo(Page));
        }
        
        public PartialViewResult GetTeacherData(Int32 Page = 1, String searshParametr = "") 
        {
            TeachersListViewModel model = new TeachersListViewModel
            {
                Teachers = _repository.Teachers
                      .Where(x => x.Surname.Contains(searshParametr) || x.Name.Contains(searshParametr) || x.Lastname.Contains(searshParametr))
                      .OrderBy(x => x.Surname)
                      .Skip((Page - 1) * _itemPerPage)
                      .Take(_itemPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = Page,
                    ItemsPerPage = _itemPerPage,
                    TotalItems = _repository.Teachers.Count()
                }
            };
            return PartialView(model);
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
                return View("Index", getPagingInfo(1));
            }
            else
            {
                return View(teacher);
            }
        }
        private PagingInfo getPagingInfo(Int32 Page)
        {
            return new PagingInfo
              {
                  CurrentPage = Page,
                  ItemsPerPage = _itemPerPage,
                  TotalItems = _repository.Teachers.Count()
              };                           
        }
        
        private  ISchoolRepositorycs _repository ;
        private  readonly Int32 _itemPerPage = 5;

    }
}
