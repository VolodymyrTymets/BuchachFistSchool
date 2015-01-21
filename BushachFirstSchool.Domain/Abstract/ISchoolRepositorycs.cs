using BushachFirstSchool.Domain.Entity;
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
         Teacher SaveTeacher(Teacher teacher);
         Teacher DeleteTeacher(Guid  Id);
         News SaveNews(News news);
         News DeleteNews(Guid Id);

    }
}
