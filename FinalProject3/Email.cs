using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FinalProject3
{
    public class Email
    {
        public string RecepientEmail { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }

        public Email()
        {
        }

        public Email(string recepientEmail, string subject, string emailBody)
        {
            RecepientEmail = recepientEmail;
            Subject = subject;
            EmailBody = emailBody;
        }

        public Email(string recepientEmail, string subject)
        {
            RecepientEmail = recepientEmail;
            Subject = subject;
        }
        
        public Boolean SendEmail(Email email)
        {
            var messageFrom = new MailAddress("nmazumd@ilstu.edu", "Festival of Trees");
            var emailMessage = new MailMessage {From = messageFrom};
            var messageTo = new MailAddress(email.RecepientEmail);
            emailMessage.To.Add(messageTo.Address);
            var messageSubject = email.Subject;
            var messageBody = email.EmailBody;
            emailMessage.Subject = messageSubject;
            emailMessage.Body = messageBody;
            emailMessage.IsBodyHtml = true;
            var mailClient = new SmtpClient("smtp.ilstu.edu");
            try
            {
                mailClient.UseDefaultCredentials = true;
                mailClient.Send(emailMessage);
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
            return true;
        }
    }
}