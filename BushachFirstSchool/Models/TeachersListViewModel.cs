using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models
{
    public class TeachersListViewModel
    {
        public PagingInfo  PagingInfo{ get; set;}
        public IEnumerable<Teacher> Teachers { get; set; }
        public String SearhParametr { get; set; }
    }
}