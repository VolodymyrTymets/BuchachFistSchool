using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Models.ConceptTheam;

namespace BushachFirstSchool.Controllers
{
    [Authorize(Roles = "admin,theacher")]
    public class ConceptThesisController : Controller
    {
        public ConceptThesisController(ISchoolRepositorycs repository) 
        {
            _repository = repository;            
        }
       
        public ActionResult Index()
        {
            var subjectTheamId = GetSubjectTheamId();
           
          
            if (subjectTheamId != Guid.Empty)
            {
                return View(GetIndexModel());
            }
            return View("Error");
        }
        public PartialViewResult getConceptThesisData()
        {
            var subjectTheamId = GetSubjectTheamId(); 
        
            return PartialView(_repository.SubjectsTheam
                                       .FirstOrDefault(x => x.TheamId == subjectTheamId)
                                       .Concepts);
        }
        public PartialViewResult Delete(Guid Id)
        {
            
            var subjectTheamId = GetSubjectTheamId();
            try
            {
                _repository.DeleteConcept(Id);
                TempData["message_ajax"] = "Пооняття успішно видалене.";
            }
           
            catch (Exception e)
            {
                TempData["message_error_ajax"] = e.Message;
            }
            return PartialView("getConceptThesisData", _repository.SubjectsTheam
                                       .FirstOrDefault(x => x.TheamId == subjectTheamId)
                                       .Concepts);
        }
        public ActionResult Add()
        {
            var subjectTheamId = GetSubjectTheamId();
            if (subjectTheamId != Guid.Empty)
            {
                return View();
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult Add(String[][] arr )
        {           
           
            try
            {
                _repository.AddConceptsToSubjectTheam(GetSubjectTheamId(), generateConcepts(arr));
                TempData["message"] = "Поняття успішно додані";
            }           
            catch (Exception e)
            {
                TempData["message_error"] = e.Message;
                return Json(new { Message = 0 });
            }
            return Json(new { Message = 1 });
        }
        private ConceptTheamListViewModel GetIndexModel()
        {
            var subjectTheamId = GetSubjectTheamId();
            var subject = _repository.Subjects
                                       .FirstOrDefault(x => x.Theams
                                                              .FirstOrDefault(theam => theam.TheamId == subjectTheamId) != null);
            var model = new ConceptTheamListViewModel
            {
                ClassName = _repository.ShoolClasses
                                       .FirstOrDefault(x => x.Subjects
                                                             .FirstOrDefault(sub => sub.SubjectId == subject.SubjectId) != null).Name,
                SubjectName = subject.Name,
                TheamName = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == subjectTheamId).Name
            };
            return model;
        }
        private IEnumerable<Concept> generateConcepts(String[][] arr)
        {
            var concepts = new List<Concept>(arr.Length);
            for (int i = 0; i < arr.Length;i++ )
            {
                var concept = new Concept
                {
                    body = arr[i][0],
                    Thesis = new Thesis { 
                        body = arr[i][1]
                    }
                };
                concepts.Add(concept);
            }
            return concepts;
        }

        private Guid GetSubjectTheamId()
        {
            return Session["SubjectTheamId"] != null ? new Guid(Session["SubjectTheamId"] as String) : Guid.Empty;
        }
        private ISchoolRepositorycs _repository;
    }
}
