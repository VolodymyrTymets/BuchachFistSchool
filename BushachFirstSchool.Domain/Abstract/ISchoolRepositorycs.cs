using BushachFirstSchool.Domain.Entity;
using BushachFirstSchool.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BushachFirstSchool.Domain.Abstract
{

    public interface ISchoolRepositorycs
    {
         IQueryable<Teacher> Teachers { get; }
         IQueryable<News> Newses { get; }
         IQueryable<Foto> Fotos { get; }
         IQueryable<SchoolClass> ShoolClasses { get; }
         IQueryable<Subject> Subjects { get; }
         IQueryable<SubjectTheam> SubjectsTheam { get; }
         IQueryable<Pupil> Pupils { get; }
         IEnumerable<Concept> Concepts { get; }
         IQueryable<Entity.Thesis> Thesises { get; }
         IQueryable<TestCollection> Tests { get; }
         IQueryable<TestResult> TestResults { get; }  
       

         Teacher SaveTeacher(Teacher teacher);
         Teacher EditTeacher(Teacher teacher);
         Teacher DeleteTeacher(Guid  Id);
         News SaveNews(News news);
         News DeleteNews(Guid Id);
         SchoolClass SaveSchoolClass(SchoolClass schollClass);
         SchoolClass EditSchoolClass(SchoolClass schollClass);
         SchoolClass DeleteSchoolClass(Guid Id);

         void AddSubjectToShoolClass(Guid IdSchoolClass, Subject suvject);
         Subject SaveSubject(Subject subject);
         Subject EditSubject(Subject subject);
         Subject DeleteSubject(Guid Id);

         void AddSubjectTheamToSubject(Guid IdSubject, SubjectTheam theam);
         SubjectTheam EditSubjectTheam(SubjectTheam theam);
         SubjectTheam DeleteSubjectTheam(Guid Id);

         void AddConceptsToSubjectTheam(Guid IdSubjectTheam, IEnumerable<Concept> concept);     
         void AddConceptsToSubjectTheam(Guid IdSubjectTheam, Concept concept);    
         Concept EditConcepts(Concept concepts);
         Concept DeleteConcept(Guid Id);
        

         void AddPupilToSchoolClass(Guid IdClass, Pupil pupil);
         Pupil EditPupil(Pupil pupil);
         Pupil DeletePupil(Guid Id);

           
         void SaveTest(Guid theamId, TestCollection testCollection);
         void DeleteTestFronTheam(Guid theamId);
         TestResult SaveTestResult(Guid testId, TestResult TestResult, String UserName);
         void DeleteTestResult(TestResult testresult);
          void EnableTest(Guid TheamId, bool Eable);
          void ChangeResultTime(Guid ResultId, DateTime time);
    }
}
