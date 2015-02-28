using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity.Test;

namespace BushachFirstSchool.Domain.Entity
{
  public class Concept
    {
        public Guid ConceptId { get; set; }
        public String body { get; set; }
        public virtual Thesis Thesis { get; set; }
        public virtual ICollection<TestD> TestesD { get; set; }
    }
}
