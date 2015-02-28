using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Domain.Entity.Test
{
  public  class TestA
    {
      public Guid TestAId { get; set; }
      public virtual Concept concept { get; set; }
      public virtual Thesis thesis { get; set; }
    }
}
