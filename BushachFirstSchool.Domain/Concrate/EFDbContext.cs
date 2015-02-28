using BushachFirstSchool.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Entity.Test;

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
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<TestCollection> TestCollections { get; set; }
        public DbSet<TestA> TestsA { get; set; }
        public DbSet<TestB> TestsB { get; set; }
        public DbSet<TestC> TestsC { get; set; }
        public DbSet<TestD> TestsD { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<AnswerA> AnswersA { get; set; }
        public DbSet<AnswerB> AnswersB { get; set; }
        public DbSet<AnswerC> AnswersC { get; set; }
        public DbSet<AnswerD> AnswersD { get; set; }
        public DbSet<SingleAnswerD> SingleAnswersD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
