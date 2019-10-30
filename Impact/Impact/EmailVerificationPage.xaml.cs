using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailVerificationPage : ContentPage
    {
        //Need to replace this with User.email
        //This constructor will generate the verification code.
        EmailSender email = new EmailSender("jacobrip8@yahoo.com", true);
        public EmailVerificationPage()
        {
            InitializeComponent();
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            /*If the user input and generated verification code match
              then verify user's account and send to the homescreen.*/
            if (!string.IsNullOrWhiteSpace(verificationCodeEntry.Text) && email.getVerificationCode() == verificationCodeEntry.Text)
            {
                DisplayAlert("Success", "Verification Successful", "OK");
                email = null;

                //Need to post to the database that the user is verified.
                Application.Current.MainPage = new TabMainPage();
            }
            else
                DisplayAlert("Error", "Invalid Verification Code", "OK");
        }
    }
}