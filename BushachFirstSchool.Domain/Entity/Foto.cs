using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BushachFirstSchool.Domain.Entity
{
    [MetadataType(typeof(FotoMetadata))]
   public partial class Foto 
    {
       public Guid FotoId { get; set; }
       public Byte[] Content { get; set; }
      
    }
}
