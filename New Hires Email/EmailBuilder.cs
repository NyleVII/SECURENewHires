using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace New_Hires_Email
{
    class EmailBuilder
    {
        

        #region EMail message
        public static void createMessage()
        {
            String server = ConfigurationManager.AppSettings["SMTP_Server"];
            string to = ConfigurationManager.AppSettings["TestAddress"];
            string from = "santymis@secure-energy.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "This is a subject - test";
            message.Body = "The example code has an @ symbol in front of the quotes and I have no idea why";
            SmtpClient client = new SmtpClient(server, Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]));
            client.EnableSsl = true;
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send e-mail on the client's behalf.
            client.UseDefaultCredentials = true; //Will use windows login credentials
            //client.UseDefaultCredentials = false;
           // client.Credentials = new NetworkCredential("santymis@secure-energy.com", "password"); //This really shouldn't be stored in plaintext, but roll with it for now

            try
            {
                client.Send(message);
                Debug.WriteLine("Message should have been sent to " + ConfigurationManager.AppSettings["TestAddress"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in createMessage: {0}", ex.ToString());
            }
        }
        #endregion


        #region Certify

        public String certifyEmailTo()
        {
            return ConfigurationManager.AppSettings["CertifyAddress"];
        }
        public String certifyEmailBody(String firstName, String lastName)
        {
            Console.WriteLine("Please provide certify access to " + firstName + " " + lastName + "\nThank you.");
            return "Please provide certify access to " + firstName + " " + lastName + "\nThank you.";
        }

        public String certifyEmailSubject(String firstName, String lastName)
        {
            return "Certify Access - " + firstName + " " + lastName;
        }

        #endregion
    }
}
