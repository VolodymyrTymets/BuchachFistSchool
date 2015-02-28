using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Infrastructure
{
    public  static class DateChanger
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }
    }
}