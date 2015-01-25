using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Concrate;

namespace BushachFirstSchool.Controllers
{
    [HandleError]
    public class NewsController : Controller
    {
        public NewsController(ISchoolRepositorycs repository) 
        {
            _repository = repository;
        }
        
        //
        // GET: /News/

        public ActionResult Index()
        {
         //   var arr = _repository.Newses.ToArray();
            return View(_repository.Newses.ToList());
        }
        public ActionResult Create() 
        {
            return View(new News());
        }
        [HttpPost]
        public ActionResult Create( News news , IEnumerable<HttpPostedFileBase> files) 
        {
            if (ModelState.IsValid)
            {
                //  var upload = Request.Files["Photo"];
                if (files != null)
                {                    
                    news.Fotos = (ICollection<Foto>)FilesToFoto(files);
                }
                try
                {
                    _repository.SaveNews(news);
                }
                catch (Exception e)
                {
                    TempData["message_error"] = e.Message.ToString();
                    return View("Create");
                }
                TempData["message"] ="Новина '"+ news.Title +"' успішно додана";
                return View("Index");
            }
            else
            {
                return View(news);
            }
           
        }

       
        private IEnumerable <Foto> FilesToFoto(IEnumerable<HttpPostedFileBase> files)
        {
            var fotos = new List<Foto>();           
            foreach (var item in files)
            {
                var foto = new Foto();
                foto.Content = item.InputStream.ToArray();
                fotos.Add(foto);              
            }
            return fotos;
        }

        private ISchoolRepositorycs _repository;
    }
}
