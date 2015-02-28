using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Test
{
    public class TestD
    {
        public Guid TestDId { get; set; }
        public virtual ICollection<Concept> concept { get; set; }
        public virtual ICollection<Thesis> thesises { get; set; }
    }
}
