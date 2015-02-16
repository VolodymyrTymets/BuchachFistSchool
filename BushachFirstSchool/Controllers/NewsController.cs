using BushachFirstSchool.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Concrate;

using BushachFirstSchool.Models;
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
         
            return View();
        }
        public PartialViewResult getNews(Int32 page = 1, String searshParametr = "", String deleteParametr = "")
        {
            DeleteNews(deleteParametr);
            IEnumerable<News> newses = _repository.Newses
                     .Where(x => x.Title.Contains(searshParametr))
                     .OrderByDescending(x => x.DataOfCreations);


            var model = new NewsListViewsModels
            {
                News = newses.Take(_itemPerPage * page).ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _itemPerPage,
                    TotalItems = newses.Count()
                }
            };
            return PartialView(model);
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

        public ActionResult Edit(Guid Id) 
        {
            return View(_repository.Newses.FirstOrDefault(x => x.NewsId == Id));
        }
        [HttpPost]
        public ActionResult Edit(News news, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {

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
                    TempData["message_error"] = e.Message;
                }
                TempData["message"] = "Новина  "+ news.Title  + " успішно відредагованa.";
                return View("Index");
            }
            else
            {
                return View(news);
            }
        }

        private void DeleteNews(String Id)
        {
            if (Id != "")
            {
                try
                {
                    var news = _repository.DeleteNews(new Guid(Id));
                    TempData["message_ajax"] = "Новина "+ news.Title + " успішно видалений.";
               } 
                catch (Exception e)
                {
                    TempData["message_error_ajax"] = e.Message;
                }
            }
        }
        private IEnumerable <Foto> FilesToFoto(IEnumerable<HttpPostedFileBase> files)
        {
            
                var fotos = new List<Foto>();
                foreach (var item in files)
                {
                    var foto = new Foto();
                    if (item != null)
                    {
                         foto.Content = item.InputStream.ToArray();
                         fotos.Add(foto);
                    }                   
                }
                return fotos;          
        }

        private ISchoolRepositorycs _repository;
        private readonly Int32 _itemPerPage = 5; 
    }
}
