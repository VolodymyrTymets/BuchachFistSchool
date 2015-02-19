using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models.Entitys
{
    public class SingleTeacher
    {
        public BushachFirstSchool.Domain.Entity.Teacher Teacher { get; set; }
        public String TeacherImageUrl { get; set; }
    }
}