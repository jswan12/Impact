using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCredentialsPage : ContentPage
    {
        public RegisterCredentialsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            passwordInfoLabel.Text = "Passwords should meet the following requirements:\n" +
                                    "\t - Be 8 to 12 characters in length\n" +
                                    "\t - Contain at least one lower case letter\n" +
                                    "\t - Contain at least one upper case letter\n" +
                                    "\t - Contain at least one numeric value (0 - 9)\n" +
                                    "\t - Contain at least one of these special characters! $ *( ) _ -";
            emailEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmPasswordEntry.Focus());
            confirmPasswordEntry.ReturnCommand = new Command(() => createAccountButton.Focus());
        }

        private async void createAccount_ButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text) && !string.IsNullOrWhiteSpace(confirmPasswordEntry.Text))
            {
                string errorMessage = validateFormEntries();
                if (errorMessage == null)
                {
                    await createLoginCredentialsAsync();
                }
                else
                    await DisplayAlert("Form Validation Error", errorMessage, "OK");
            }
            else
                await DisplayAlert("Form Validation Error", "Fields can not be empty", "OK");
        }

        private string validateFormEntries()
        {
            string errorMessage = null;
            if (!emailEntry.Text.Contains("@"))
                errorMessage += "- Invaild email address format\n";
            if (!emailEntry.Text.EndsWith(".edu"))
                errorMessage += "- Email entry must be a valid university email\n";
            string passwordFaults = validPassword();
            if (passwordFaults != null)
                errorMessage += passwordFaults;
            else
            {
                if (!string.Equals(passwordEntry.Text, confirmPasswordEntry.Text))
                    errorMessage += "- Your passwords do not match\n";
            }
            return errorMessage;
        }

        private string validPassword()
        {
            string errorMessage = null;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!$*()_-]");

            if (!hasMiniMaxChars.IsMatch(passwordEntry.Text))
                errorMessage += "- Password should be 8 to 12 characters in length\n";
            else if (!hasLowerChar.IsMatch(passwordEntry.Text))
                errorMessage += "- Password should contain at least one lower case letter\n";
            else if (!hasUpperChar.IsMatch(passwordEntry.Text))
                errorMessage += "- Password should contain at least one upper case letter\n";
            else if (!hasNumber.IsMatch(passwordEntry.Text))
                errorMessage += "- Password should contain at least one numeric value (0 - 9)\n";
            else if (!hasSymbols.IsMatch(passwordEntry.Text))
                errorMessage += "- Password should contain at least one of these special characters! $ *( ) _ -\n";
            return errorMessage;
        }
        
        private async Task createLoginCredentialsAsync()
        {
            try
            {
                activityIndicator.IsRunning = true;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var newLoginCredentials_JSON = new StringContent(JsonConvert.SerializeObject(new { Email_Address = emailEntry.Text, Password = passwordEntry.Text }), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(new Uri("https://asp-impact.azurewebsites.net/api/Login"), newLoginCredentials_JSON);
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        App.currentUser = JsonConvert.DeserializeObject<User>(responseBody, deserializationSettings);

                        //User Successfully created
                        Application.Current.MainPage = new EmailVerificationPage(App.currentUser.email_address);
                    }
                    else
                        await DisplayAlert("Title", responseBody, "OK");
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