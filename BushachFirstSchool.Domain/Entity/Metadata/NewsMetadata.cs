using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace BushachFirstSchool.Domain.Entity
{
   public partial class NewsMetadata
    {
        public Guid NewsId { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [Display(Name = "Заголовок")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Title { get; set; }
        [Required(ErrorMessage = "Заповніть дане поле")]
        [Display(Name = "Опис")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

       // [HiddenInput(DisplayValue = false)]
        public DateTime DataOfCreations { get; set; }

     
        [Display(Name = "Фото")]
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
