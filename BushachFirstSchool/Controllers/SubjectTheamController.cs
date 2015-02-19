using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Models.SubjectTheamModel;

namespace BushachFirstSchool.Controllers
{
    public class SubjectTheamController : Controller
    {
        public SubjectTheamController(ISchoolRepositorycs repository) 
        {
            _repository = repository;            
        }

        public ActionResult Index()
        {
            var subjectId = GetSubjectId();
            if (subjectId != Guid.Empty)
            {
                var model = new SubjectTheamListViewModel
                {
                    SubjectTheam = new SubjectTheam(),
                    SubjectName = _repository.Subjects.FirstOrDefault(x => x.SubjectId == subjectId).Name,
                    ClassName = _repository.ShoolClasses.FirstOrDefault(x =>
                                                                            x.Subjects.FirstOrDefault(subject =>
                                                                            subject.SubjectId == subjectId) != null).Name
                };
                
                return View(model);
            }
            return PartialView("Error", null);
            
        }

        public PartialViewResult getSubjectTheamData()
        {
            return PartialView(getSubjectTheams(GetSubjectId()));
        }
        public PartialViewResult Add(SubjectTheam theam)
        {
            var subjectId = GetSubjectId();
            if (subjectId != Guid.Empty)
            {
                try
                {
                    _repository.AddSubjectTheamToSubject(GetSubjectId(), theam);
                    TempData["message_ajax"] = "Тема успішно доданий.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                }
                

                return PartialView("getSubjectTheamData", getSubjectTheams(GetSubjectId()));
            }
            return PartialView("Error", null);
        }
        public PartialViewResult Delete(String Id)
        {
            if (GetSubjectId() != Guid.Empty)
            {                
                try
                {
                    _repository.DeleteSubjectTheam(new Guid(Id));
                    TempData["message_ajax"] = "Тема успішно видалена.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                }
               
                return PartialView("getSubjectTheamData", getSubjectTheams(GetSubjectId()));
            }
            return PartialView("Error", null);
        }


        private IEnumerable<SubjectTheam> getSubjectTheams(Guid subjectId)
        {
            return _repository.Subjects
                                          .FirstOrDefault(x => x.SubjectId == subjectId)
                                          .Theams.ToList();
        }
      
        private Guid GetSubjectId()
        {
            return Session["SubjectId"] != null ? new Guid(Session["SubjectId"] as String) : Guid.Empty;
        }
        private ISchoolRepositorycs _repository;
    }
}
