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
        EmailSender email;
        public EmailVerificationPage(string recipientEmail)
        {
            InitializeComponent();
            email = new EmailSender(recipientEmail, true);
            recipientEmailLabel.Text = recipientEmail;
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            /*If the user input and generated verification code match
              then verify user's account and send to the homescreen.*/
            if(!string.IsNullOrWhiteSpace(verificationCodeEntry.Text) && string.Equals(email.getVerificationCode(), verificationCodeEntry.Text))
            {
                await DisplayAlert("Success", "Verification Successful", "OK");
                email = null;

                //TODO
                //Need to post to the database that the user is verified.

                Application.Current.MainPage = new TabMainPage();
            }
            else
                await DisplayAlert("Error", "Invalid Verification Code", "OK");
        }
    }
}