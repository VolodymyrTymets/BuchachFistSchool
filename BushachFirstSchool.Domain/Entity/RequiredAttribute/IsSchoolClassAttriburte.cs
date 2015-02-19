using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BushachFirstSchool.MyRequiredAttribute
{
    public class IsSchoolClassAttriburte : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null ? Regex.IsMatch(value.ToString(), "^[0-9]{2}-[A-Za-z]{1}$") : true;
        }
    }

}