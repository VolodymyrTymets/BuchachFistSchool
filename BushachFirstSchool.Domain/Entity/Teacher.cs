using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Entity
{
 public   class Teacher
    {
     public Guid TeacherId { get; set; }
     public String Name { get; set; }
     public String Surname { get; set; }
     public String Lastname { get; set; }
     public String Description { get; set; }     
     public Foto Foto { get; set; }
    }
}
