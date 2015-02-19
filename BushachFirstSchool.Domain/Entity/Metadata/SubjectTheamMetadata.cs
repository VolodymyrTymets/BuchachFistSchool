using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Metadata
{
    public partial class SubjectTheamMetadata
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [Display(Name = "Назва")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Name { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
        public virtual ICollection<Thesis> Thesises { get; set; }
    }
}
