using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Domain.Entity.Test
{
    public class TestResult
    {
        public Guid TestResultId { get; set; }
        public virtual ICollection<AnswerA>  testAColl { get; set; }
        public virtual ICollection<AnswerB> testBColl { get; set; }
        public virtual ICollection<AnswerC> testCColl { get; set; }
        public virtual ICollection<AnswerD> testDColl { get; set; }
        public virtual Pupil Pupil { get; set; }
        public DateTime RemainderTime { get; set; }
    }
  
    public class AnswerA
    {
        public Guid AnswerAId { get; set; }
        public Int16 answer {get ; set;}
        public Guid conceptId { get; set; }
        public Guid thesisId { get; set; } 
    }
     public class AnswerB
    {
         public Guid AnswerBId { get; set; }
         public Guid conceptId { get; set; } 
         public Guid thesisId { get; set; } 
    }
     public class AnswerC
    {
         public Guid AnswerCId { get; set; }
         public String answer {get ; set;}
         public Guid conceptId { get; set; } 
        
    }
     public class AnswerD
    {
         public Guid AnswerDId { get; set; }
         public virtual ICollection<SingleAnswerD> SingleAnswerD { get; set; }
    
    }
     public class SingleAnswerD
     {
         public Guid SingleAnswerDId { get; set; }
         public Guid conceptId { get; set; }
         public Guid thesisId { get; set; }
     }
   
}
