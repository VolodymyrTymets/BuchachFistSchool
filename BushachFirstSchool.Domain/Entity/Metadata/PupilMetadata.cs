using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity.Metadata
{
    public partial class PupilMetadata
    {
        public Guid PupilId { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        [Display(Name = "Імя")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        [Display(Name = "Прізвище")]
        public String Surname { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        [Display(Name = "По батькові")]
        public String Lastname { get; set; }
    }
}
