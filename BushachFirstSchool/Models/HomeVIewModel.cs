using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Teacher> Teacher { get; set; }
        public IEnumerable<News> News { get; set; }
    }
}