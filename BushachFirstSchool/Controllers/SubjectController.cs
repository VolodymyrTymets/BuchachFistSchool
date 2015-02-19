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
                var teacher = _repository.Teachers.FirstOrDefault(x => x.TeacherId == new Guid(teacherId));
                subject.Teacher = teacher;
                _repository.AddSubjectToShoolClass(GetSchoolClassId(), subject);

                return PartialView("getSubjectData", getSubjects(GetSchoolClassId()));
            }
            return PartialView("Error", null);
        }
        public PartialViewResult Delete(String Id)
        {
            if (GetSchoolClassId() != Guid.Empty)
            {
                _repository.DeleteSubject(new Guid(Id));
                return PartialView("getSubjectData", getSubjects(GetSchoolClassId()));
            }
            return PartialView("Error", null);
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
