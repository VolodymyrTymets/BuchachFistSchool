using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models.SubjectModel
{
    public class SubjectIndexViewModel
    {
        public Subject Subject { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public String ClassNme { get; set; }
    }
}