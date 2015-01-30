using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models
{
    public class MailModel
    {
        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [EmailAddress(ErrorMessage = "Невірний формат")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Organization { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [Range(1, 11,  ErrorMessage = "Невірний формат")]
        [StringLength(11, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 11 символів")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
        public String Subject { get; set; }

        [Required(ErrorMessage = "Заповніть дане поле")]
        public String Message { get; set; }
    }
}