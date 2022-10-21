using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Modeles
{
    public class Utilitaires
    {
        public static string ConvertirEnMajuscules(string nom)
        {
            return nom.ToUpper();
        }

        public static void EnvoyerEmail(string htmlString, string emailDestinataire)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("bmask6539@gmail.com");
                message.To.Add(new MailAddress(emailDestinataire));
                message.Subject = "CONFIRMATION DE RDV";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("bmask6539@gmail.com", "blackmask6539");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}

// test push