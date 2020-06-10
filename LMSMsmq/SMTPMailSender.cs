//
// Author: Vinayak Ushakola
// Date: 25/05/2020
//

using System.Net;
using System.Net.Mail;

namespace LMSMsmq
{
    public class SMTPMailSender
    {
        /// <summary>
        /// It is used to Send Mail
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="email">Email</param>
        /// <returns>If Mail Sent Successfully return true else false</returns>
        public static bool SendMail(string token, string email)
        {

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(token))
            {

                string FROMNAME = "Vinayak Ushakola", FROM = "vinayak.mailtesting@gmail.com", TO = email, SUBJECT = "Reset Password";
                int PORT = 587;
                string message = "\nClick on this link to Reset your password: https://localhost:44314/api/user/resetpassword \nCopy this token & paste in your postman: " + token;
                var BODY = "Hi," + message;

                MailMessage mailMessage = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com", PORT);
                mailMessage.From = new MailAddress(FROM, FROMNAME);
                mailMessage.To.Add(new MailAddress(TO));
                mailMessage.Subject = SUBJECT;
                mailMessage.Body = BODY;

                client.Credentials = new NetworkCredential(FROM, "@bcd.1234");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mailMessage);

                return true;
            }
            return false;
        }
    }
}
