using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity.Test;

namespace BushachFirstSchool.Domain.Entity
{
    public  class Thesis
    {
        [Key]
        public Guid ThesisId { get; set; }
        public String body { get; set; }
        public virtual ICollection<TestD> TestesD { get; set; }
        public virtual ICollection<TestB> TestesB { get; set; }
    }
}
