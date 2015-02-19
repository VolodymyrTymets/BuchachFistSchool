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
        Int32 RegisterPupil(String username, String email);
        Int32 RegisretTeacher(String username, String email);
        bool ChangePassword(String oldPassword, String newPassword);
    }
}