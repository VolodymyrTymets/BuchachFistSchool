using BushachFirstSchool.Domain.Entity.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BushachFirstSchool.Domain.Entity
{
    [MetadataType(typeof(SchoolClassMetadata))]
    public  partial class SchoolClass
    {
        public Guid SchoolClassId { get; set; }        
        public String Name { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

    }
}
