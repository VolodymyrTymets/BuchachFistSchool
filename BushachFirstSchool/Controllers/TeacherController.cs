using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Concrate;
using BushachFirstSchool.Models;
using System.Threading;


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
        
        public PartialViewResult GetTeacherData(Int32 Page = 1, String searshParametr = "", String deleteParametr = "") 
        {
           // Thread.Sleep(2000);
            DeleteTeacher(deleteParametr);
            IEnumerable<Teacher> teachers = _repository.Teachers
                      .Where(x => x.Surname.Contains(searshParametr) || x.Name.Contains(searshParametr) || x.Lastname.Contains(searshParametr))
                      .OrderBy(x => x.Surname);

            
            TeachersListViewModel model = new TeachersListViewModel
            {
                Teachers = teachers.Skip((Page - 1) * _itemPerPage)
                                   .Take(_itemPerPage),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = Page,
                    ItemsPerPage = _itemPerPage,
                    TotalItems = teachers.Count()
                }
            };
            return PartialView(model);
        }

        [Authorize(Roles = "admin")]
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
                try
                {
                    _repository.SaveTeacher(teacher);
                }
                catch (Exception e) 
                {
                    TempData["message_error"] = e.Message;
                }
                TempData["message"] = teacher.Surname + " " + teacher.Name + " успішно зареєстрований(на).";
                return View("Index", getPagingInfo(1));
            }
            else
            {
                return View(teacher);
            }
        }
        public FileContentResult GetImage(Guid Id)
        {
            var foto = _repository.Teachers.FirstOrDefault(x => x.TeacherId==Id).Foto; ;
            if (foto != null)
            {
                return File(foto.Content, foto.FotoId.ToString());
            }
            else
            {
                return null;
            }
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid Id)
        {   
            return View(_repository.Teachers.FirstOrDefault(x => x.TeacherId == Id));
        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher  )
        {
            if (ModelState.IsValid)
            {
               
                if (teacher.PhotoBytes != null)
                {
                    teacher.Foto = new Foto();
                    teacher.Foto.Content = teacher.PhotoBytes.InputStream.ToArray();                   
                }
                try
                {
                    _repository.SaveTeacher(teacher);
                }
                catch (Exception e) 
                {
                    TempData["message_error"] = e.Message;
                }
                TempData["message"] = teacher.Surname + " " + teacher.Name + " успішно відредагований.";
                return View("Index", getPagingInfo(1));
            }
            else
            {
                return View(teacher);
            }
        }
        [HttpPost]
        public ActionResult Delete(Guid Id)
        {
            return GetTeacherData(1);
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
        private void DeleteTeacher(String Id)
        {
            if (Id != "")
            {
                try 
                { 
                    var teacher = _repository.DeleteTeacher(new Guid(Id));
                    TempData["message_ajax"] = teacher.Surname + " " + teacher.Name + " успішно видалений.";
                }
                catch (Exception e) 
                {
                    TempData["message_error_ajax"] = e.Message;
                }
            }
        }
        
        private  ISchoolRepositorycs _repository ;
        private  readonly Int32 _itemPerPage = 4;

    }
}
