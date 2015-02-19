using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models.PupilModel
{
    public class PupilCreateViewModel
    {
        public BushachFirstSchool.Domain.Entity.Pupil Pupil { get; set; }
        public UserData UserData { get; set; }
    }
}