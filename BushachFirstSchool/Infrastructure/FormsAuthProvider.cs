using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BushachFirstSchool.Infrastructure.Abstract;
using System.Web.Security;
using BushachFirstSchool.Filters;
using WebMatrix.WebData;
using System.Linq;


namespace BushachFirstSchool.Infrastructure
{
    [InitializeSimpleMembership]
    public class FormsAuthProvider  : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result; 
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public String RegisterPupil(string username, string email)
        {

            String Password = GenereteRandomPassword(_passwordLength);
            WebSecurity.CreateUserAndAccount(username, Password);
            if (!Roles.RoleExists("people"))
            {
                Roles.CreateRole("people");
            }
            Roles.AddUserToRole(username, "people");
            EmailSender.SendRegisterMessage(email,Password,username);
            return username;
        }

        public String RegisretTeacher(string username, string email)
        {
            String Password = GenereteRandomPassword(_passwordLength);
          //  Membership.CreateUser(username, Password,email);
            WebSecurity.CreateUserAndAccount(username, Password);
            if (!Roles.RoleExists("theacher"))
            {
                Roles.CreateRole("theacher");
            }
            Roles.AddUserToRole(username, "theacher");           
            //EmailSender.SendRegisterMessage(email, Password, username);
            return username;

        }      

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            var u = Membership.GetUser(HttpContext.Current.User.Identity.Name);
            return     u.ChangePassword(oldPassword, newPassword);
        }
        private String GenereteRandomPassword(Int32 passwordLength)
        {
            return Guid.NewGuid().ToString().Substring(0, passwordLength);
        }

        private const Int32 _passwordLength = 6;



        public void DeleteUser(String userName)
        {            
            if (Roles.GetRolesForUser(userName).Count() > 0)
            {
                Roles.RemoveUserFromRoles(userName, Roles.GetRolesForUser(userName));
            }
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(userName); // deletes record from webpages_Membership table
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(userName, true); // deletes record from UserProfile table
        }


        
    }
}