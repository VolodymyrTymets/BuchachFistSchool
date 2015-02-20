using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Models.SubjectModel;

namespace BushachFirstSchool.Controllers
{
    public class SubjectController : Controller
    {

        public SubjectController(ISchoolRepositorycs repository) 
        {
            _repository = repository;            
        }

        public ActionResult Index()
        {
            var schoolClassId = GetSchoolClassId();
            if (schoolClassId == Guid.Empty)
            {
                return View("Error",null);
            }
            var model = new SubjectIndexViewModel
            {
                Teachers = _repository.Teachers.ToList(),
                Subject = new Subject(),
                ClassNme = _repository.ShoolClasses.FirstOrDefault(x => x.SchoolClassId == schoolClassId).Name
            };
            return View(model);
        }
       
        public PartialViewResult getSubjectData( )
        {
            return PartialView(getSubjects(GetSchoolClassId()));
        }
        public PartialViewResult Add(Subject subject, String teacherId) 
        {
            if (GetSchoolClassId() != Guid.Empty)
            {
                try
                {
                    var teacher = _repository.Teachers.FirstOrDefault(x => x.TeacherId == new Guid(teacherId));
                    subject.Teacher = teacher;
                    _repository.AddSubjectToShoolClass(GetSchoolClassId(), subject);
                    TempData["message_ajax"] = subject.Name + " успішно доданий.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                }
                

                return PartialView("getSubjectData", getSubjects(GetSchoolClassId()));
            }
            return PartialView("Error", null);
        }
        public PartialViewResult Delete(String Id)
        {
            if (GetSchoolClassId() != Guid.Empty)
            {
                try
                {
                    _repository.DeleteSubject(new Guid(Id));
                    TempData["message_ajax"] = "Предмет успішно видалений.";
                }
                catch (FieldAccessException ) 
                {
                    TempData["message_error_ajax"] = "Ви не можите видалити предмет, поки йому належить хоть одна тема. Спершу видаліть усі теми цього предмету.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                }
                
                return PartialView("getSubjectData", getSubjects(GetSchoolClassId()));
            }
            return PartialView("Error", null);
        }
        public ActionResult Details(Guid Id)
        {
            Session["SubjectId"] = Id.ToString();
            return RedirectToAction("Index", "SubjectTheam");
        }

        private IEnumerable<Subject> getSubjects(Guid shoolClassId) 
        {
            return _repository.ShoolClasses
                                          .FirstOrDefault(x => x.SchoolClassId == shoolClassId)
                                          .Subjects.ToList();
        }
        private Guid GetSchoolClassId()
        {            
           return  Session["ShoolClassId"] != null ? new Guid(Session["ShoolClassId"] as String) : Guid.Empty;
        }      
        private ISchoolRepositorycs _repository;
     
    }
}
