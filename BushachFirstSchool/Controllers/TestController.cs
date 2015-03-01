using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity.Test;
using BushachFirstSchool.Domain.Concrate;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Models.Test;
using System.IO;
using BushachFirstSchool.Infrastructure;


namespace BushachFirstSchool.Controllers
{
    public class TestController : Controller
    {

        public TestController(ISchoolRepositorycs repository) 
        {
            _repository = repository;            
        }
        [Authorize(Roles = "admin,theacher")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin,theacher")]
        public ActionResult List(String theamId)
        {
           
                return View(GetListModel(new Guid(theamId)));
            
        }
        [HttpPost]
        public PartialViewResult EnableTest(Guid Id) 
        {
            var val = Request.Form["enable"];
            if (val == "on")
            {
                _repository.EnableTest(Id, true);
            }
            else
            {
                _repository.EnableTest(Id,false);
            }
            return PartialView("_ajaxMessage");
        }
        [HttpPost]
        public PartialViewResult SetResultTime(Guid Id)
        {
            var val =   Convert.ToInt32 (Request.Form["time"]);
            var time = DateTime.Now.ChangeTime(0, val, 0, 0);
            _repository.ChangeResultTime(Id, time);

            return PartialView("_ajaxMessage");
        }
        [Authorize(Roles = "admin,theacher")]
        public ActionResult Generate(String theamId)
        {
            //TestCollection model = GetTestCollection(new Guid(theamId));
            var model = new TestGenerateViewModel
            {
                TheamId = new Guid(theamId),
                TestGenericOptionsViewModel = new TestGenericOptionsViewModel
                {
                    countThesisInTestB = 4,
                    countThesisInTestD = 4,
                    countTestA = 5,
                    countTestB = 5,
                    countTestC = 5,
                    countTestD = 1,
                    ratingTestA = 25,
                    ratingTestB = 25,
                    ratingTestC = 25,
                    ratingTestD = 25,
                    Durarion = 20
                }
            };
            return View(model);
        }
        [Authorize(Roles = "people")]
        public ActionResult Past(String theamId)
        {
            //TestCollection model = GetTestCollection(new Guid(theamId));
            var TheamId = new Guid(theamId);
           var test = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == TheamId).TestCollection;
           TestResult result ;
            try
           {
               result = test.TestResults.FirstOrDefault(x => x.Pupil.userName == User.Identity.Name);
           }
           catch 
           {
               result = null;
            }
           if (test.Enable == true )
           {
               if(result != null && result.RemainderTime.Minute == 0 )
               {
                   return View("TestPermisionError");
               }
               var model = new TestPastViewModel
               {
                   TestCollection = test,
                   TestResult = result
               };
               return View(model);
           }
          
            return View("TestPermisionError");
          
        }
        [HttpPost]
        public ActionResult Past(Guid Id, TestResult testResult)
        {         
          var testId = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == Id ).TestCollection.TestCollectionId;
          testResult.RemainderTime =   testResult.RemainderTime.ChangeTime(0,0,0,0);
     
          var testIni = new TestInitializer();
          Int16 CountOfPasetTest = 0;
          var rating = testIni.RequireTest(testId, testResult, _repository, ref CountOfPasetTest);
          testResult.Rating = rating;
          var testresult = _repository.SaveTestResult(testId, testResult, User.Identity.Name);
          var model = new TestResultViewModel
          {
              CountPasetTest = CountOfPasetTest,
              Rating = rating,
              CountOfTest = CountOfPasetTest
          };
          if(Request.IsAjaxRequest())
          {
                return Json(new {  div = RenderRazorViewToString("TestResult",model)});
          }
          return View();
        }
        [HttpPost]
        public ActionResult PastTemporary(Guid Id, TestResult testResult)
        {
            try
           {
                var testId = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == Id).TestCollection.TestCollectionId;
                var testresult = _repository.SaveTestResult(testId, testResult, User.Identity.Name);
            }
            catch
            {
                return Json(new { Message = 0 });
            }
            return Json(new { Message = 1 });
        }
        public PartialViewResult TestResult( TestResultViewModel model ) 
        {
            return PartialView("TestResult", model);
        }
        [Authorize(Roles = "admin,theacher")]
        public ActionResult Results(String theamId)
        {            
            var TheamId = new Guid(theamId);
            var results = _repository.SubjectsTheam
                                     .FirstOrDefault(x => x.TheamId == TheamId)
                                     .TestCollection
                                     .TestResults;      
            return View(results);
        }
        public ActionResult DeleteTest(String theamId)
        {
            _repository.DeleteTestFronTheam(new Guid(theamId));
            return RedirectToAction("List", theamId);
        }
        [Authorize(Roles = "admin,theacher")]
        public ActionResult SingleResult(String resultId)
        {
            
            var TestResultId = new Guid(resultId);
            var results = _repository.TestResults
                                     .FirstOrDefault(test => test.TestResultId == TestResultId);
            var tests = _repository.Tests
                                     .FirstOrDefault(x => x.TestResults
                                                           .FirstOrDefault(res => res.TestResultId == results.TestResultId) != null);                                   

             var model = new SingleResultsViewModel
             {
                 TestCollection = tests,
                 TestResult = results
             };
             return View(model);

        }
        public PartialViewResult GetGeneratedTests(TestGenericOptionsViewModel testopt) 
        {
            String TheamId = null;
            TestCollection tests =null;
            try
               {
                     TheamId = Request.QueryString["theamId"].ToString();
                     tests = GetTestCollection(new Guid(TheamId),testopt);
                     _repository.DeleteTestFronTheam(new Guid(TheamId));
                    _repository.SaveTest(new Guid(TheamId), tests);
                    
             }
           catch (Exception e)
               {
                   TempData["message_error_ajax"] = e.Message;
                   return PartialView("GenerateError", null);
               }
            return PartialView(tests);
        }
        public PartialViewResult GetTests(Guid theamId)
        {
            return PartialView(_repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == theamId).TestCollection);
        }
        private TestCollection GetTestCollection(Guid Id, TestGenericOptionsViewModel testopt)
        {
            var listconcept = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == Id).Concepts;
            var listThesis = new List<Thesis>(listconcept.Count);
            foreach (var item in listconcept)
            {
                listThesis.Add(item.Thesis);
            }
            var testini = new TestInitializer(testopt.countThesisInTestB, 
                                              testopt.countThesisInTestD,
                                              testopt.countTestA,
                                              testopt.countTestB,
                                              testopt.countTestC,
                                              1,
                                              testopt.ratingTestA,
                                              testopt.ratingTestB,
                                              testopt.ratingTestC,
                                              testopt.ratingTestD,
                                              testopt.Durarion);
            
            return testini.GenetrateTest(listconcept, listThesis);
        }
        private TestListViewModel GetListModel(Guid subjectTheamId)
        {
            
            var subject = _repository.Subjects
                                       .FirstOrDefault(x => x.Theams
                                                              .FirstOrDefault(theam => theam.TheamId == subjectTheamId) != null);

            var testcol = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == subjectTheamId).TestCollection;
            var model = new TestListViewModel 
            {
                ClassName = _repository.ShoolClasses
                                       .FirstOrDefault(x => x.Subjects
                                                             .FirstOrDefault(sub => sub.SubjectId == subject.SubjectId) != null).Name,
                SubjectName = subject.Name,
                TheamName = _repository.SubjectsTheam.FirstOrDefault(x => x.TheamId == subjectTheamId).Name,
                TestEnabel = testcol != null ?  testcol.Enable : false
            };
            return model;
        }
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        private ISchoolRepositorycs _repository;

    }
}
