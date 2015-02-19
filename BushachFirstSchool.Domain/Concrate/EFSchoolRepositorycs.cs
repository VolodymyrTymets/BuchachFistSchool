﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BushachFirstSchool.Domain.Abstract;
using BushachFirstSchool.Domain.Entity;
namespace BushachFirstSchool.Domain.Concrate
{
  public  class EFSchoolRepositorycs  : ISchoolRepositorycs
    {
        
      private EFDbContext _context = new EFDbContext();


 
      public IQueryable<Entity.Foto> Fotos
      {
          get { return _context.Fotos; }
      }

      /**********************-----Teacher-----************************/
      public IQueryable<Entity.Teacher> Teachers
      {
          get { return _context.Teachers; }
      }
      public Teacher SaveTeacher(Entity.Teacher teacher)
      {      
       if (teacher.TeacherId == Guid.Empty)
       {
           teacher.TeacherId = Guid.NewGuid();  
       }
           if(teacher.Foto != null )
           {
               teacher.Foto.FotoId = Guid.NewGuid();
           }
           _context.Teachers.Add(teacher);
          _context.SaveChanges();
          return teacher;
      }
      public Teacher EditTeacher(Entity.Teacher teacher)
      {
          Entity.Teacher dbEntry = _context.Teachers.Find(teacher.TeacherId);
          if (dbEntry != null)
          {
              dbEntry.Name = teacher.Name;
              dbEntry.Surname = teacher.Surname;
              dbEntry.Lastname = teacher.Lastname;
              dbEntry.Description = teacher.Description;
              dbEntry.Work = teacher.Work;
              if (teacher.Foto != null)
              {
                  teacher.Foto.FotoId = Guid.NewGuid();
                  dbEntry.Foto = teacher.Foto;
              }
          }
          _context.SaveChanges();
          return teacher;
      }
      public  Teacher DeleteTeacher(Guid Id)
      {
         Teacher dbEntry = _context.Teachers.Find(Id);
          if (dbEntry != null)
          {
              _context.Teachers.Remove(dbEntry);
              _context.SaveChanges();
          }
          return dbEntry;
      }

      /**********************-----News-----***************************/
      public IQueryable<Entity.News> Newses
      {
          get { return _context.Newses; }
      }
      public News SaveNews(Entity.News news)
      {
          if (news.NewsId == Guid.Empty)
          {
              news.NewsId = Guid.NewGuid();
              news.DataOfCreations = DateTime.Now;
              if (news.Fotos != null)
              {
                  foreach (var item in news.Fotos)
                  {
                      item.FotoId = Guid.NewGuid();
                  }
              }
              _context.Newses.Add(news);
          }
          else
          {
              Entity.News dbEntry = _context.Newses.Find(news.NewsId);
              if (dbEntry != null)
              {
                  dbEntry.Title = news.Title;
                  dbEntry.Description = news.Description;
                  if (news.Fotos.Count() != 0)
                  {
                      foreach (var item in news.Fotos)
                      {
                          item.FotoId = Guid.NewGuid();
                      }
                      dbEntry.Fotos = news.Fotos;
                  }

              }
          }
          _context.SaveChanges();
          return news;
      }
      public News DeleteNews(Guid Id)
      {

         var dbEntry = _context.Newses.Find(Id);
          if (dbEntry != null)          {

              dbEntry.Fotos.ToList().ForEach(x => _context.Fotos.Remove(x));
              _context.Newses.Remove(dbEntry);
              _context.SaveChanges();
          }
          return dbEntry;
      }

      /**********************-----ShoolClasses-----*******************/
      public IQueryable<SchoolClass> ShoolClasses
      {
          get { return _context.SchoolClases; }
      }
      public SchoolClass SaveSchoolClass(SchoolClass schollClass)
      {
          if (schollClass.SchoolClassId == Guid.Empty)
          {
              schollClass.SchoolClassId = Guid.NewGuid();
          }
          _context.SchoolClases.Add(schollClass);
          _context.SaveChanges();
          return schollClass;
      }
      public SchoolClass EditSchoolClass(SchoolClass schollClass)
      {
          Entity.SchoolClass dbEntry = _context.SchoolClases.Find(schollClass.SchoolClassId);
          if (dbEntry != null)
          {
              dbEntry.Name = schollClass.Name;
              if (schollClass.Subjects != null)
              {
                  dbEntry.Subjects = schollClass.Subjects;
              }
          }
          _context.SaveChanges();
          return schollClass;
      }
      public SchoolClass DeleteSchoolClass(Guid Id)
      {
          var dbEntry = _context.SchoolClases.Find(Id);
          if (dbEntry != null)
          {

              //dbEntry.Fotos.ToList().ForEach(x => _context.Fotos.Remove(x));
              _context.SchoolClases.Remove(dbEntry);
              _context.SaveChanges();
          }
          return dbEntry;
      }
      public void AddSubjectToShoolClass(Guid IdSchoolClass , Subject subject) 
      {
          if (subject.SubjectId == Guid.Empty)
          {
              subject.SubjectId = Guid.NewGuid();
          }
         var dbEntry = _context.SchoolClases.Find(IdSchoolClass);
         if (dbEntry.Subjects == null) 
         {
             dbEntry.Subjects = new List<Subject>();
         }
         dbEntry.Subjects.Add(subject);
         _context.SaveChanges();
      }

      /**********************-----SubjectClasses-----*******************/
      public IQueryable<Subject> Subjects
      {
          get { return _context.Subjects; }
      }
      public Subject SaveSubject(Subject subject)
      {
          if (subject.SubjectId == Guid.Empty)
          {
              subject.SubjectId = Guid.NewGuid();
          }
          _context.Subjects.Add(subject);
          _context.SaveChanges();
          return subject;
      }
      public Subject EditSubject(Subject subject)
      {
          Entity.Subject dbEntry = _context.Subjects.Find(subject.SubjectId);
          if (dbEntry != null)
          {
              dbEntry.Name = subject.Name;            
  
              if (subject.Teacher != null)
              {
                  dbEntry.Teacher = subject.Teacher;
              }
              if (subject.Theams != null)
              {
                  dbEntry.Theams = subject.Theams;
              }
          }
          _context.SaveChanges();
          return subject;
      }
      public Subject DeleteSubject(Guid Id)
      {
          var dbEntry = _context.Subjects.Find(Id);
          if (dbEntry != null)
          {

              //dbEntry.Fotos.ToList().ForEach(x => _context.Fotos.Remove(x));
              _context.Subjects.Remove(dbEntry);
              _context.SaveChanges();
          }
          return dbEntry;
      }
    }
}
