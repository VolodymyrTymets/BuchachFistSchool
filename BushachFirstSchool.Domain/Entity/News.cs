using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
[MetadataType(typeof(NewsMetadata))]
 public  partial class News
    {
     
     public Guid NewsId { get; set; }
     public String Title { get; set; }
     public String Description { get; set; }
     public DateTime DataOfCreations { get; set; }
     public virtual ICollection<Foto> Fotos { get; set; }
    }
}
