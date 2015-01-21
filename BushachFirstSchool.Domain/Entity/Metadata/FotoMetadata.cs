using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
    public partial class FotoMetadata
    {
        public Guid FotoId { get; set; }
        [Required(ErrorMessage = "Виберіть Фото")]
        public Byte[] Content { get; set; }
    }
}
