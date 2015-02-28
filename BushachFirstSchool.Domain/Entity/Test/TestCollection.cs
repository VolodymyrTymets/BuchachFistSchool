using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Test
{
  public  class TestCollection
    {
      public Guid TestCollectionId { get; set; }
      public virtual ICollection<TestA> TeststACol { get; set; }
      public virtual ICollection<TestB> TeststBCol { get; set; }
      public virtual ICollection<TestC> TeststCCol { get; set; }
      public virtual ICollection<TestD> TeststDCol { get; set; }
      public Int32 TestARating { get; set; }
      public Int32 TestBRating { get; set; }
      public Int32 TestCRating { get; set; }
      public Int32 TestDRating { get; set; }
      public Int32 Duration { get; set; }
      public Boolean Enable { get; set; }

      public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
