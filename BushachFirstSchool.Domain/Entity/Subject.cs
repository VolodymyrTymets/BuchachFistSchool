using BushachFirstSchool.Domain.Entity.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
   [MetadataType(typeof(SubjectMetadata))]
   public  partial class Subject
    {
        public Guid SubjectId { get; set; }
        public String Name { get; set; }
        public virtual Teacher Teacher { get; set; }
        public  virtual ICollection<SubjectTheam> Theams { get; set; }


    }
}
