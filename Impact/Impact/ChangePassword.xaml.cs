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
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
            changePassword.ReturnCommand = new Command(() => confirmChangePassword.Focus());
            confirmChangePassword.ReturnCommand = new Command(() => submitPasswordChange.Focus());
        }
        private string ValidChangePassword()
        {
            string errorMessage = null;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!$*()_-]");

            if (!hasMiniMaxChars.IsMatch(changePassword.Text))
                errorMessage += "- Password should be 8 to 12 characters in length\n";
            else if (!hasLowerChar.IsMatch(changePassword.Text))
                errorMessage += "- Password should contain at least one lower case letter\n";
            else if (!hasUpperChar.IsMatch(changePassword.Text))
                errorMessage += "- Password should contain at least one upper case letter\n";
            else if (!hasNumber.IsMatch(changePassword.Text))
                errorMessage += "- Password should contain at least one numeric value (0 - 9)\n";
            else if (!hasSymbols.IsMatch(changePassword.Text))
                errorMessage += "- Password should contain at least one of these special characters! $ *( ) _ -\n";
            return errorMessage;
        }

        private async Task changePasswordAsync()
        {
            try
            {
                activityIndicator.IsRunning = true;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var changePassword_JSON = new StringContent(JsonConvert.SerializeObject(new { Password = changePassword.Text }), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(new Uri("https://asp-impact.azurewebsites.net/api/Login"), changePassword_JSON);
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });

                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        App.currentUser = JsonConvert.DeserializeObject<User>(responseBody, deserializationSettings);

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


        private async void submitPasswordChange_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePassword());
        }
    }
}
