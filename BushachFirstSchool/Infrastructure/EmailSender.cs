using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using BushachFirstSchool.Models;
using System.Text;

namespace BushachFirstSchool.Infrastructure
{
    public static class EmailSender
    {
        public static void EmailSend(MailModel model) 
        {
            using (var smtpClient = new SmtpClient())
            {
                
                MailMessage message = new MailMessage();
                message.Subject = "Повідомлення від користувача сайту";
                StringBuilder body = new StringBuilder();
                body.Append("Дані користувача:<br>");
                body.Append("   *<i>Імя: </i>" + model.Name + "<br>");
                body.Append("   *<i>Організація: </i>" + model.Organization + "<br>");
                body.Append("   *<i>Email: </i>" + model.Email + "<br>");
                body.Append("   *<i>Телефон: :</i>" + model.Phone + "<br>");

                body.Append("<br> <b>Тема:</b> " + model.Subject);
                body.Append("<br> <br>" + model.Message);
                message.To.Add(smtpClient.Credentials.GetCredential(smtpClient.Host, smtpClient.Port, "SSL").UserName);
                message.Body = body.ToString();
                message.IsBodyHtml = true;
                smtpClient.Send(message);

            }
        }
    }
}