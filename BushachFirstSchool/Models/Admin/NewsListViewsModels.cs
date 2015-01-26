using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models
{
    public class NewsListViewsModels
    {
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<News> News { get; set; }
        public String SearhParametr { get; set; }
    }
}