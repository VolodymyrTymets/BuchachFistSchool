using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Concrate
{
   public class EFDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<SchoolClass> SchoolClases { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectTheam> SubjectTheams { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Thesis> Thesises { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
