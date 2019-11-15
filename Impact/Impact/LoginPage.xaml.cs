using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                activityIndicator.IsRunning = true;
                using (HttpClient client = new HttpClient())
                {
                    // Tell the HttpClient that we are accepting json back
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Sent a GET REQUEST to the ASP.NET api to validate the login credentials
                    // We're expecting to receive a Status Code and Content Body back
                    HttpResponseMessage response = await client.GetAsync(new Uri(string.Format("https://asp-impact.azurewebsites.net/api/Login?email_address=" + email_AddressEntry.Text + "&password=" + passwordEntry.Text)));

                    // If the User's credentials are found in the database,
                    // we will construct a new User (our current user)
                    if (response.StatusCode == System.Net.HttpStatusCode.Found || response.StatusCode == System.Net.HttpStatusCode.PartialContent)
                    {
                        // We format the response content into "Newtonsoft Parseable JSON"
                        string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });

                        // Use Newtonsoft Package to create the current User object and apply the json values to their session (Ignoring Null and Missing Values)
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        App.currentUser = JsonConvert.DeserializeObject<User>(responseBody, deserializationSettings);
                        App.currentUser.email_address = email_AddressEntry.Text;

                        // Navigate to the Home Page with Tab Group
                        if(response.StatusCode == System.Net.HttpStatusCode.PartialContent)
                            App.instance.ClearNavigationAndGoToPage(new EmailVerificationPage(App.currentUser.email_address));
                        else
                        {
                            if (string.IsNullOrEmpty(App.currentUser.name))
                                App.instance.ClearNavigationAndGoToPage(new RegistrationPage());
                            else
                                App.instance.ClearNavigationAndGoToPage(new TabMainPage());
                        } 
                    }
                    // If the User's credentials are not found in the database,
                    // we will display an alert to the user
                    else
                    {
                        // In this case the response content will be a string saying "Invalid Login Credentials".
                        string responseContent = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                        await DisplayAlert("Invalid Login Credentials", responseContent, "OK");
                    }
                }
            }
            catch (HttpRequestException exception)
            {
                await DisplayAlert("Http Request Exception", exception.Message, "OK");
            }
            catch (Exception exception)
            {
                await DisplayAlert("Unhandled Exception", exception.Message, "OK");
            }
            finally
            {
                activityIndicator.IsRunning = false;
            }
        }
    }
}