using BushachFirstSchool.Domain.Entity.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace BushachFirstSchool.Domain.Entity
{
    public partial class TeacherMetadata
    {
        public Guid TeacherId { get; set; }   

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

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        [Display(Name = "Посада")]
        public String Work { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [Display(Name = "Про вчителя")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Display(Name = "Фото")]        
        public Foto Foto { get; set; }

        
        [Display(Name = "Виберіть фото")]
        [NotMapped]
        [ValidateFile]
        public HttpPostedFileBase PhotoBytes{ get; set;}

     
    }
}
