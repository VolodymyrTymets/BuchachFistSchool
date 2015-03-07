using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models
{
    
        public struct UserData
        {
            [Required(ErrorMessage = "Заповніть дане поле")]
            [StringLength(20, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 20 символів")]
            [Display(Name = "Логін")]
            public String UserName { get; set; }



            [Required(ErrorMessage = "Заповніть дане поле")]
            [EmailAddress(ErrorMessage = "Невірний формат")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина поля становить від 3 до 50 символів")]
            [Display(Name = "Email")]
            public String Email { get; set; }

            [Required(ErrorMessage = "Заповніть дане поле")]
            [DataType(DataType.Password)]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "Довжина паролю становить від 5 до 10 символів")]
            [Display(Name = "Пароль")]
            public String Password { get; set; }
        }
    
}