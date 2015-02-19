using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Controllers
{
    public class SchoolClassController : Controller
    {
        public SchoolClassController(ISchoolRepositorycs repository) 
        {
            _repository = repository;
      
        }

        public ActionResult Index()
        {             
            return View(new SchoolClass());
        }
        
        public PartialViewResult getShoolClassData( SchoolClass scholClass = null, String deleteParametr = null)
        {  
            AddNewShollCalas(scholClass);
            DeleteShollCalas(deleteParametr);

            return PartialView(_repository.ShoolClasses.ToList());
        }
        public ActionResult DetailsSubject(Guid Id) 
        {
            Session["ShoolClassId"] = Id.ToString();
            return RedirectToAction("Index", "Subject");
        }
        public ActionResult DetailsPupil(Guid Id)
        {
            Session["ShoolClassId"] = Id.ToString();
            return RedirectToAction("List", "Pupil");
        }
        private void AddNewShollCalas(SchoolClass scholClass)
        {
            if(scholClass != null && scholClass.Name != null)
            {
                try
                {
                    _repository.SaveSchoolClass(scholClass);
                    TempData["message_ajax"] = scholClass.Name + " клас  успішно доданий.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                    return;                    
                }
               
                
            }
        }
        private void DeleteShollCalas(String deleteParametr)
        {
            if (deleteParametr != null)
            {
             try{
                    _repository.DeleteSchoolClass(new Guid(deleteParametr));
                    TempData["message_ajax"] = "Клас успішно видалений.";
                }
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                    return;                    
                }
           
            }
        }
        
        private ISchoolRepositorycs _repository;
     
    }
}
