using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Models.PupilModel;
using BushachFirstSchool.Infrastructure.Abstract;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Filters;

namespace BushachFirstSchool.Controllers
{
    [InitializeSimpleMembership]
    public class PupilController : Controller
    {
        public PupilController(ISchoolRepositorycs repository , IAuthProvider auth) 
        {
            _repository = repository;
            _authProvider = auth;
        }

        [Authorize(Roles = "admin")]
        public ActionResult List()
        {
            var schoolClassId = GetSchoolClassId();
            if (schoolClassId == Guid.Empty)
            {
                return View("Error", null);
            }
            var pipilCreateViewModel = new PupilCreateViewModel
            {
                Pupil = new Pupil(),
                UserData = new Models.UserData()
            };
            var model = new PupilListViewModel
            {
                PupilCreateViewModel = pipilCreateViewModel,
                ClassNme = _repository.ShoolClasses.FirstOrDefault(x => x.SchoolClassId == schoolClassId).Name
            };
            return View(model);
        }

        public PartialViewResult getPupilsData()
        {
            return PartialView(getPupils(GetSchoolClassId()));
        }
        public PartialViewResult Add(PupilCreateViewModel model)
        {
            if (GetSchoolClassId() != Guid.Empty)
            {
                if (ModelState.IsValid)
                {   
                  try{
                        model.Pupil.userName = _authProvider.RegisterPupil(model.UserData.UserName, model.UserData.Email);
                        _repository.AddPupilToSchoolClass(GetSchoolClassId(), model.Pupil);
                        TempData["message_ajax"] =   model.Pupil.Surname + " " +   model.Pupil.Name + " успішно доданий.";
                     }
                  catch (Exception e) 
                     {
                        TempData["message_error_ajax"] = e.Message;
                     }
                }
                return PartialView("getPupilsData", getPupils(GetSchoolClassId()));
            }
            return PartialView("Error", null);
        }
        public PartialViewResult Delete(String Id)
        {
            if (GetSchoolClassId() != Guid.Empty)
            {
              try{  
                    var pupil =  _repository.DeletePupil(new Guid(Id));
                    _authProvider.DeleteUser(pupil.userName);                   
                    TempData["message_ajax"] =   pupil.Surname + " " +   pupil.Name + " успішно видалений.";
                 }
             catch (Exception e) 
                 {
                    TempData["message_error_ajax"] = e.Message;
                 }
              return PartialView("getPupilsData", getPupils(GetSchoolClassId()));
            }
            return PartialView("Error", null);
        }
        private IEnumerable<Pupil> getPupils(Guid shoolClassId)
        {
            return _repository.ShoolClasses
                                          .FirstOrDefault(x => x.SchoolClassId == shoolClassId)
                                          .Pupils.ToList();
        }
        private Guid GetSchoolClassId()
        {
            return Session["ShoolClassId"] != null ? new Guid(Session["ShoolClassId"] as String) : Guid.Empty;
        }
        
        private ISchoolRepositorycs _repository;
        private IAuthProvider _authProvider;

    }
}
