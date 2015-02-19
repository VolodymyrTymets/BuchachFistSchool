using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models.SubjectTheamModel
{
    public class SubjectTheamListViewModel
    {
        public SubjectTheam SubjectTheam { get; set;}
        public String ClassName { get; set; }
        public String SubjectName { get; set; }
    }
}