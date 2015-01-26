using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Models.Entitys
{
    public class ForoCarousel
    {
        public IEnumerable<Foto> Foto { get; set; }
        public String CuralesId { get; set; }
    }
}