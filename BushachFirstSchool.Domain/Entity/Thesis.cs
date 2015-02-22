using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
    public  class Thesis
    {
        [Key]
        public Guid ThesisId { get; set; }
        public String body { get; set; }
    }
}
