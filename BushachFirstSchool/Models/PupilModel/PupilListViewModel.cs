using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models.PupilModel
{
    public class PupilListViewModel
    {
        public PupilCreateViewModel PupilCreateViewModel { get; set; }      
        public String ClassNme { get; set; }
    }
}