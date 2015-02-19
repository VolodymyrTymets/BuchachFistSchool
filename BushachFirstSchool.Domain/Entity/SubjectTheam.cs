using BushachFirstSchool.Domain.Entity.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
   [MetadataType(typeof(SubjectTheamMetadata))]
   public partial class SubjectTheam
   {
       [Key]
        public Guid TheamId { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Concept> Concepts { get; set; }
        public virtual ICollection<Thesis> Thesises { get; set; }


    }
}
