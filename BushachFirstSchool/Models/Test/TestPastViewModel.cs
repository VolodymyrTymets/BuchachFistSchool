using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity.Test;

namespace BushachFirstSchool.Models.Test
{
    public class TestPastViewModel
    {
        public TestCollection TestCollection { get; set; }
        public TestResult TestResult { get; set; }
    }
}