using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
 public  class News
    {
     
     public Guid NewsId { get; set; }
     public String Title { get; set; }
     public String Description { get; set; }
     public virtual ICollection<Foto> Fotos { get; set; }
    }
}
