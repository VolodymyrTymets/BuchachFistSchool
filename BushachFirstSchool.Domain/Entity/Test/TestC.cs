using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Test
{
   public class TestC
    {
       public Guid TestCId { get; set; }
       public virtual Thesis thesis { get; set; }
    }
}
