using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity;

namespace BushachFirstSchool.Domain.Concrate
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var students = new List<Teacher> 
            { 
                new Teacher {Name = "vova", Surname = "vaasda",  Description = "sadasds" , Lastname = "asdadasdasd" }, 
                new Teacher {Name = "vova", Surname = "vaasda",  Description = "sadasds" , Lastname = "asdadasdasd" }, 
                new Teacher {Name = "vova", Surname = "vaasda",  Description = "sadasds" , Lastname = "asdadasdasd" }, 
                new Teacher {Name = "vova", Surname = "vaasda",  Description = "sadasds" , Lastname = "asdadasdasd" }, 
               
            };
            students.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

        
        }
    } 
}
