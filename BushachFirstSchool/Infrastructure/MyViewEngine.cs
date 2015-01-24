using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BushachFirstSchool.Infrastructure
{
    public class MyViewEngine : RazorViewEngine
    {
         private static string[] NewPartialViewFormats = new[] { 
                                        "~/Views/{1}/Partials/{0}.cshtml",
                                        "~/Views/Shared/Entitys/{0}.cshtml"
                                       };

         public MyViewEngine()
    {
        base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
    }   
    }
}