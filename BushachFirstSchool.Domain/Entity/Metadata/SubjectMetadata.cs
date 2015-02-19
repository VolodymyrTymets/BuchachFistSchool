using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Metadata
{
    public partial class SubjectMetadata
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [Display(Name = "Назва")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Виберіть із списку")]
        [Display(Name = "Вчителі")]
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<SubjectTheam> Theams { get; set; }
    }
}
