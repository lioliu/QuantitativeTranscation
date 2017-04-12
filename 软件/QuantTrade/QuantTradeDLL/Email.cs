using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuantTradeDLL
{
    public class Email
    {
        /// <summary>
        /// Sent email to target location
        /// </summary>
        /// <param name="EmailAdress">target email adress</param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool Sent(string EmailAdress, string Message)
        {
            if (Message.Equals(string.Empty))
            {
                return false;
            }
            MailAddress from, to;
            from = new MailAddress("lmjlio@foxmail.com", "admin");
            try
            {
                to = new MailAddress(EmailAdress, "user");
            }
            catch (Exception e)
            {
                throw e;
            }
            

            MailMessage mail = new MailMessage()
            {
                From = from,
                Subject = "股票预警" + DateTime.Now.ToString(),
                Body = Message,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            };
            mail.To.Add(to);

            SmtpClient client = new SmtpClient("smtp.qq.com")
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("744596028@qq.com", "`6y4r7u0p9o4r")
            };

            client.Send(mail);
            
            return true;
        }
    }
}
