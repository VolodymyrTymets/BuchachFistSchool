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
using BushachFirstSchool.Infrastructure.Abstract;
using BushachFirstSchool.Models.TeacherModel;
using BushachFirstSchool.Filters;
using WebMatrix.WebData;


namespace BushachFirstSchool.Controllers
{
    [InitializeSimpleMembership]
    public class TeacherController : Controller
    {
        public TeacherController( ISchoolRepositorycs repository, IAuthProvider auth) 
        {
            _repository = repository;
            _authProvider = auth;
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

      //  [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View(new TeacherCreateViewModel());
        }
        [HttpPost]
        public ActionResult Create( TeacherCreateViewModel model  )
        {
            if (ModelState.IsValid)
            {
              //  var upload = Request.Files["Photo"];
                if (model.Teacher.PhotoBytes != null)
                {
                    model.Teacher.Foto = new Foto();
                    model.Teacher.Foto.Content = model.Teacher.PhotoBytes.InputStream.ToArray();                   
                }
                try
                {
                    model.Teacher.userName =   _authProvider.RegisretTeacher(model.UserData.UserName, model.UserData.Email);
                    _repository.SaveTeacher(model.Teacher);
               }
                catch (Exception e) 
                {
                    TempData["message_error"] = e.Message;
                    return View();
                }
                TempData["message"] = model.Teacher.Surname + " " + model.Teacher.Name + " успішно зареєстрований(на).";
                return View("Index", getPagingInfo(1));
            }
            else
            {
                return View(model);
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
                    TempData["message"] = teacher.Surname + " " + teacher.Name + " успішно відредагований.";
                }
                try
                {
                    _repository.EditTeacher(teacher);
                }
                catch (Exception e) 
                {
                    TempData["message_error"] = e.Message;
                }
                
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

        public ActionResult PersonalPage() 
        {
            return View();
        }
       

        public PartialViewResult getSubject( Guid IdClass)
        {
            return PartialView(getSubjectBelongToTeacher(IdClass));
        }
        public PartialViewResult getClasses()
        {
            return PartialView(getClassesInWhichTeacherHasSubject());
        }
        public ActionResult RedirectToTheamPage(Guid Id)
        {
            Session["SubjectId"] = Id.ToString();
            return RedirectToAction("Index", "SubjectTheam");
        }

        private IEnumerable<SchoolClass> getClassesInWhichTeacherHasSubject()
        {
            var teacherId = _repository.Teachers.FirstOrDefault(x => x.userName == WebSecurity.CurrentUserName).TeacherId;
            return _repository.ShoolClasses.Where(x => x.Subjects
                                                .Where(subject => subject.Teacher.TeacherId == teacherId).Count() != 0)
                                                .Select(schoolClass => schoolClass).ToList();
        }
        private IEnumerable<Subject> getSubjectBelongToTeacher(Guid IdClass)
        {
            var teacherId = _repository.Teachers.FirstOrDefault(x => x.userName == WebSecurity.CurrentUserName).TeacherId;
            return _repository.ShoolClasses
                                          .FirstOrDefault(x => x.SchoolClassId == IdClass)
                                          .Subjects
                                          .Where(subject => subject.Teacher.TeacherId == teacherId)
                                          .ToList();
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
                    _authProvider.DeleteUser(teacher.userName);
                    TempData["message_ajax"] = teacher.Surname + " " + teacher.Name + " успішно видалений.";
                }
                catch (FieldAccessException)
                {
                    TempData["message_error_ajax"] = "Ви не можите видалити вчителя, поки він належить хоть до одного предмет. Спершу видаліть усі предмети звязані з ним.";
                }
                catch (Exception e) 
                {
                    TempData["message_error_ajax"] = e.Message;
                }
            }
        }
        
        private  ISchoolRepositorycs _repository ;
        private IAuthProvider _authProvider;
        private  readonly Int32 _itemPerPage = 4;

    }
}
