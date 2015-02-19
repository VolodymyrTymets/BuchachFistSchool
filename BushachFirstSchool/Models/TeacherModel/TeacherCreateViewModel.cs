using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Models;

namespace BushachFirstSchool.Models.TeacherModel
{
    public class TeacherCreateViewModel
    {
        public BushachFirstSchool.Domain.Entity.Teacher Teacher {get;set;}
        public UserData UserData { get; set; }
    }
}