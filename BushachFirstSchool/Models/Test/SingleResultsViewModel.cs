using BushachFirstSchool.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models.Test
{
    public class SingleResultsViewModel
    {
        public TestCollection TestCollection { get; set; }
        public TestResult TestResult { get; set; }
    }
}