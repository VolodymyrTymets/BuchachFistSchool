using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Test
{
   public class TestB
    {
       public Guid TestBId { get; set; }
       public virtual Concept concept { get; set; }
       public virtual ICollection<Thesis> thesises { get; set; }
    }
}
