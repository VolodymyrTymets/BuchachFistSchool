using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BushachFirstSchool.Controllers
{
    public class FotoController : Controller
    {
         public FotoController(ISchoolRepositorycs repository) 
        {
            _repository = repository;
        }
        public FileContentResult GetImage(Guid Id)
        {
            var foto = _repository.Fotos.FirstOrDefault(x => x.FotoId == Id);
            if (foto != null)
            {
                return File(foto.Content, "image/jpeg");
            }
            else
            {
                return null;
            }
        }
       private ISchoolRepositorycs _repository;
        

    }
}
