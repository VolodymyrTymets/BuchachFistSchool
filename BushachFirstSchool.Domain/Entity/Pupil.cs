using BushachFirstSchool.Domain.Entity.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
  [MetadataType(typeof(PupilMetadata))]
  public partial  class Pupil
    {
        public Guid PupilId { get; set; }
        //  public Guid? FotoId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Lastname { get; set; }
        public String userName { get; set; }
    }
}
