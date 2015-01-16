using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using BushachFirstSchool.Domain.Concrate;
using System.Data.Entity;
using BushachFirstSchool.Domain.Entity;


namespace BushachFirstSchool
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

         //   Database.SetInitializer<EFDbContext>(new SchoolInitializer());
          //  EFSchoolRepositorycs rep = new EFSchoolRepositorycs();
          //  rep.SaveTeacher(new Teacher);
          //  Teacher_Change_Without_Foto();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
       
        public void Teacher_Add_With_Foto()
        {
            //Arrage           
            Teacher teacher1 = new Teacher
            {
                Name = "BillFoto",
                Surname = "Yohan",
                Lastname = "Will",
                Description = "fak as  as  as asdasd",

            };
            Foto foto = new Foto
            {
                FotoId = Guid.NewGuid()
            };
            teacher1.Foto = foto;
            //Act
            _repository.SaveTeacher(teacher1);
            //Assert
            var result = _repository.Teachers.ToList().Find(x => x.Name == "BillFoto");
            
        }
        public void Teacher_Change_Without_Foto()
        {
            //Arrage
            var teacher1 = _repository.Teachers.ToList().Find(x => x.Name == "BillFoto");
            teacher1.Name = "BillChangeTest";
            //Act
            _repository.SaveTeacher(teacher1);
            //Assert
            var result = _repository.Teachers.ToList().Find(x => x.Name == "BillChangeTest");
            
        }
        private readonly EFSchoolRepositorycs _repository = new EFSchoolRepositorycs();
    }
}