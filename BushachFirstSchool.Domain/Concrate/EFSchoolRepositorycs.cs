using System;
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

      public IQueryable<Entity.Teacher> Teachers
      {
          get { return _context.Teachers; }
      }

      public IQueryable<Entity.News> Newses
      {
          get { return _context.Newses; }
      }
      public IQueryable<Entity.Foto> Fotos
      {
          get { return _context.Fotos; }
      }

      public Teacher SaveTeacher(Entity.Teacher teacher)
      {      
       if (teacher.TeacherId == Guid.Empty)
       {
           teacher.TeacherId = Guid.NewGuid();     
           if(teacher.Foto != null )
           {
               teacher.Foto.FotoId = Guid.NewGuid();
           }
           _context.Teachers.Add(teacher);               
       }
          else
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

     
    }
}
