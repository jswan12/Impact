using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Linq;

namespace Impact
{
    public class EmailSender
    {
        // Initializations
        private MailMessage mail = new MailMessage();
        private static SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        private string verificationCode = null;
        private MailAddress ImpactEmail = new MailAddress("noreply@Impact.org");

        /// <summary>
        /// Calling this constructor will throw an exception 
        /// becasue no email recipients will have been specified.
        /// </summary>
        public EmailSender() => throw new NotSupportedException("An email recipient must be specified");

        /// <summary>
        /// Create a new Email from "noreply.LS.Impact@gmail.com" to the recipientEmail
        /// </summary>
        /// <param name="recipientEmail"></param>
        public EmailSender(string recipientEmail, bool verificationEmail = false, string subject = "Impact Emailing System", string body = "This is a System Test\nPlease disregard this message")
        {
            if (verificationEmail)
                InitializeEmailContent(true, "Verification Code", "Your verification code is: ");
            else
                InitializeEmailContent(false, subject, body);

            mail.To.Add(recipientEmail);
            SendEmail();
        }

        public EmailSender(string[] recipientEmails, string subject = "Impact Emailing System", string body = "This is a System Test\nPlease disregard this message")
        {
            InitializeEmailContent(false, subject, body);

            foreach (string eAddress in recipientEmails)
            {
                mail.To.Add(eAddress);
                SendEmail();
                mail.To.Clear();
            }
        }

        /// <summary>
        /// Initialize Smtp Server and Create the Email Contents
        /// </summary>
        private void InitializeEmailContent(bool verificationEmail, string subject, string body)
        {
            mail.From = mail.Sender = ImpactEmail;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(Keys.SmtpEmail, Keys.SmtpPassword);
            SmtpServer.EnableSsl = true;

            mail.Subject = subject;
            mail.Body = body;

            if (verificationEmail)
            {
                setNewVerificationCode();
                mail.Body += verificationCode;
            }
        }

        /// <summary>
        /// Send Verification Email to Recipient
        /// </summary>
        private void SendEmail()
        {
            if (mail.To != null)
            {
                try { SmtpServer.Send(mail); }
                catch { throw new SmtpFailedRecipientException(); }
            }
            else
                throw new Exception("No recipient emails have been added to the mailing list");
        }

        /// <summary>
        /// Get the Email Verification Code 
        /// </summary>
        /// <returns>Current Verification Code as a string</returns>
        public string getVerificationCode() => verificationCode;

        /// <summary>
        /// Set the Email Verification Code 
        /// </summary>
        /// <param name="Nullify">Optional Paramater to Nullify the Verification Code</param>
        public void setNewVerificationCode(bool Nullify = false)
        {
            if (Nullify)
                verificationCode = null;
            else
                verificationCode = GenerateVerificationCode();
        }

        /// <summary>
        /// Generate a 6 Digit Verification Code
        /// </summary>
        /// <returns>6 Digit Verification Code as a string</returns>
        private static string GenerateVerificationCode()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateVerificationCode();
            }
            return r;
        }
    }
}
