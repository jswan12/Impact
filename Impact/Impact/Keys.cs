using System;
using System.Collections.Generic;
using System.Text;

namespace Impact
{
    public static class Keys
    {
        #error You need to set up your SMTP Credentials.
        /* You need to add in the credentials for the gmail account that emails will        *
         * be sent from. Make sure that you turn "Less secure app access" on for your       *
         * account. This information is needed for the SMTP Server to send the actual email */
        public static string SmtpEmail = "<Email@gmail.com>";
        public static string SmtpPassword = "<Password>";
        public static string SmtpPassword = "<Password>";
    }
}
