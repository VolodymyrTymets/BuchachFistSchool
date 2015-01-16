using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BushachFirstSchool.Domain.Entity
{
   public  class Foto 
    {
       public Guid FotoId { get; set; }
       public Byte[] Content { get; set; }
      
    }
}
