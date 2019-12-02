using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public EmailVerificationPage(string recipientEmail, bool hasBackButton = false)
        {
            InitializeComponent();
            if (hasBackButton)
                NavigationPage.SetHasNavigationBar(this, true);
            else
                NavigationPage.SetHasNavigationBar(this, false);
            email = new EmailSender(recipientEmail, true);
            recipientEmailLabel.Text = recipientEmail;
            verificationCodeEntry.Focus();
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            /*If the user input and generated verification code match
              then verify user's account and send to the homescreen.*/
            if(!string.IsNullOrWhiteSpace(verificationCodeEntry.Text) && string.Equals(email.getVerificationCode(), verificationCodeEntry.Text))
            {
                email = null;
                await updateUsersVerificationStatus();
            }
            else
                await DisplayAlert("Error", "Invalid Verification Code", "OK");
        }

        private async Task updateUsersVerificationStatus()
        {
            try
            {
                activityIndicator.IsRunning = true;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PutAsync(new Uri("https://asp-impact.azurewebsites.net/api/Login"), new StringContent(App.currentUser.credentials_id.ToString(), Encoding.UTF8, "application/json"));
                    var responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        // Email Set to Verified.
                        await DisplayAlert("Success", "Email Verification Successful", "OK");

                        if (string.IsNullOrEmpty(App.currentUser.name))
                            App.instance.ClearNavigationAndGoToPage(new RegistrationPage());
                        else
                            App.instance.ClearNavigationAndGoToPage(new TabMainPage());
                    }
                    //Couldnt Find Credentials with credentials_id provided of the current user
                    //This should never happen with the database foreign key reference !!!!
                    else
                        await DisplayAlert("Error", responseBody, "OK");
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message, "OK");
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }
    }
}