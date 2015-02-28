using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models.Test
{
    public class TestResultViewModel
    {
        public Int16 CountPasetTest { get; set; }
        public Int16 CountOfTest { get; set; }
        public Decimal Rating { get; set; }
        public Decimal Rating5System { get { return Rating / 20; ; } }
        public Decimal Rating12System { get { return Rating / 8.3m; } }
        public String LanguageRating
        {
            get
            {
                if (Rating < 60)
                {
                    return "Погано";
                }
                else if (Rating <= 75)
                {
                    return "Добре";
                }
                else if (Rating <= 80)
                {
                    return "Задовільно";
                }
                else if (Rating <= 90)
                {
                    return "Дуже добре";
                }
                else
                {
                    return "Відмінно";
                }
            }
        }
        public String AlertClass
        {
            get
            {
                if (Rating < 60)
                {
                    return "alert-danger";
                }
                else if (Rating <= 75)
                {
                    return "alert-warning";
                }
                else if (Rating <= 80)
                {
                    return "alert-success";
                }
                else if (Rating <= 90)
                {
                    return "alert-info";
                }
                else
                {
                    return "alert-info";
                }
            }
        }
    }
}