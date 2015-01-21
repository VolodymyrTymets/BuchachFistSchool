using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BushachFirstSchool.Domain.Entity
{
 [MetadataType(typeof(TeacherMetadata))]
 public   partial class Teacher
    {

     public Guid TeacherId { get; set; }   
     public String Name { get; set; }  
     public String Surname { get; set; }     
     public String Lastname { get; set; }
     public String Description { get; set; } 
     public Foto Foto { get; set; }
     public HttpPostedFileBase PhotoBytes { get;  set;}
    }
}
