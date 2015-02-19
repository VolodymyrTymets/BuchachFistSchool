using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.MyRequiredAttribute;

namespace BushachFirstSchool.Domain.Entity.Metadata
{
  public  partial class SchoolClassMetadata
    {
      public Guid SchoolClassId { get; set; }    
      [Required(ErrorMessage = "Заповніть дане поле")]
      [IsSchoolClassAttriburte(ErrorMessage="Дане поле аовинно бути типй 1-А")]   
      [Display(Name = "Назва")]
      public String Name { get; set; }
      public virtual ICollection<Subject> Subjects { get; set; }
        
    }
}
