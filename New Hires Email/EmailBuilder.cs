using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace New_Hires_Email
{
    class EmailBuilder
    {
        static string username;
        static SecureString userPass;

        public void toSecureString(MainWindow window)
        {
            username = window.emailLoginTextBox.Text;

            userPass = new SecureString();
            foreach (char c in window.passwordBox.Password.ToString())
            {
                userPass.AppendChar(c);
            }
            Debug.WriteLine(userPass);
        }

        #region EMail message
        public static void createMessage(MainWindow window)
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
            client.Credentials = new NetworkCredential(username, userPass); //This really shouldn't be stored in plaintext, but roll with it for now


            Debug.WriteLine(CredentialCache.DefaultNetworkCredentials.UserName);

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

        public String certifyEmailSubject(String firstName, String lastName)
        {
            return "Certify Access - " + firstName + " " + lastName;
        }

        public String certifyEmailBody(String firstName, String lastName)
        {
            return "Please provide certify access to " + firstName + " " + lastName + "\nThank you.";
        }
        #endregion

        #region Mudtrac

        public String mudtracEmailTo()
        {
            return ConfigurationManager.AppSettings["MudtracAddress"];
        }

        public String mudtracEmailSubject(String firstName, String lastName)
        {
            return "Mudtrac Access - " + firstName + " " + lastName;
        }

        public String mudtracEmailBody(String firstName, String lastName)
        {
            return "Please provide Mudtrac access to " + firstName + " " + lastName + "\nThank you.";
        }
        #endregion

        #region Solver

        public String solverEmailTo()
        {
            return ConfigurationManager.AppSettings["SolverAddress"];
        }

        public String solverEmailSubject(String firstName, String lastName)
        {
            return "Solver Access - " + firstName + " " + lastName;
        }

        public String solverEmailBody(String firstName, String lastName)
        {
            return "Please provide solver access to " + firstName + " " + lastName + "\nThank you.";
        }

       
        #endregion
    }
}
