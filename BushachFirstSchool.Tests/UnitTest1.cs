using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BushachFirstSchool.Domain.Concrate;
using BushachFirstSchool.Domain.Entity;
using System.Linq;

namespace BushachFirstSchool.Tests
{
    [TestClass]
    public class EFSchoolRepositorycsDomain
    {
        [TestMethod]
        public void Teacher_Add_Without_Foto()
        {
            //Arrage           
            Teacher teacher1 = new Teacher
            {   
                Name = "Bill",
                Surname = "Yohan",
                Lastname = "Will",
                Description = "fak as  as  as asdasd",
            
            };
            //Act
            _repository.SaveTeacher(teacher1);
            //Assert
            var result = _repository.Teachers.ToList().Find(x => x.Name == "Bill");
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Teacher_Add_With_Foto()
        {
            //Arrage           
            Teacher teacher1 = new Teacher
            {
                Name = "BillFoto",
                Surname = "Yohan",
                Lastname = "Will",
                Description = "fak as  as  as asdasd",

            };
            Foto foto = new Foto
            {
                FotoId  = Guid.NewGuid()
            };
            teacher1.Foto = foto;
            //Act
            _repository.SaveTeacher(teacher1);
            //Assert
            var result = _repository.Teachers.ToList().Find(x => x.Name == "BillFoto");
            Assert.IsNotNull(result);
        }
         [TestMethod]
        public void Teacher_Change_Without_Foto()
        {
            //Arrage
            Teacher teacher1 = new Teacher
            {
                Name = "BillFoto",
                Surname = "Yohan",
                Lastname = "Will",
                Description = "fak as  as  as asdasd",

            };
            
            //Act
            _repository.SaveTeacher(teacher1);
            teacher1.Name = "BillChangeTest";
            _repository.SaveTeacher(teacher1);
            //Assert
            var result = _repository.Teachers.ToList().Find(x => x.Name == "BillChangeTest");
            Assert.IsNotNull(result);
        }
         [TestMethod]
         public void Teacher_Delete()
         {
             //Arrage
             Teacher teacher1 = new Teacher
             {
                 Name = "Bill",
                 Surname = "Yohan",
                 Lastname = "Will",
                 Description = "fak as  as  as asdasd",
             };

             //Act
            var  id =  _repository.SaveTeacher(teacher1).TeacherId;
            _repository.DeleteTeacher(id);
             //Assert
             var result = _repository.Teachers.Count();
             Assert.AreEqual(result,0);
         }
        private  readonly EFSchoolRepositorycs _repository = new EFSchoolRepositorycs();
    }
}
