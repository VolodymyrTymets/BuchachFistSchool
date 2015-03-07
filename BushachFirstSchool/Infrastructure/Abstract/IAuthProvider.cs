using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BushachFirstSchool.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(String username, String password);
        void Logout();
        String RegisterPupil(String username, String email ,String Password);
        String RegisretTeacher(String username, String email,String Password);
        bool ChangePassword(String oldPassword, String newPassword);
        void DeleteUser(String userName);
    }
}