using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Models.Test
{
    public class TestGenericOptionsViewModel
    {
      [Required(ErrorMessage = "Заповніть дане поле")]
      [UIHint("Number")]
      [Display(Name = "Кількість запитань у тесті другого типу")]
      [Range(4, 10,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public  Int32 countThesisInTestB { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")] 
      [Display(Name = "Кількість запитань у тесті четвертого типу")]
      [Range(4, 20,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public  Int32 countThesisInTestD { get; set; }

      [UIHint("Number")]  
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Кількість тестів першого типу")]
      [Range(4, 25,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public  Int32 countTestA { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Кількість тестів другого типу")]
      [Range(4, 25,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public  Int32 countTestB { get; set; }

      [UIHint("Number")]
      [Range(4, 25,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Кількість тестів третьо типу")]
      public  Int32 countTestC { get; set; }

      [UIHint("Number")]  
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Кількість тестів четвертого типу")]
      [Range(4, 25,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public  Int32 countTestD { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Відсоток за тест  першого типу(у відсотках)")]                  
      public  Int32 ratingTestA { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Відсоток за тест  другого типу(у відсотках)")]    
      public  Int32 ratingTestB { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Відсоток за тест  третього типу(у відсотках)")] 
      public  Int32 ratingTestC { get; set; }

      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Відсоток за тест  четвертого типу(у відсотках)")] 
      public  Int32 ratingTestD  { get; set; }
     
      [UIHint("Number")]
      [Required(ErrorMessage = "Заповніть дане поле")]
      [Display(Name = "Тривалість тесту (у хвилинах)")] 
      [Range(5, 55,
      ErrorMessage = "Значення  {0} повинно бути між  {1} і {2}.")]
      public Int32 Durarion { get; set; }

    }
}