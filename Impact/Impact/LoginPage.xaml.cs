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
        public static User currentUser { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.LoginPage_content, true);
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
                    if (response.StatusCode == System.Net.HttpStatusCode.Found)
                    {
                        // We format the response content into "Newtonsoft Parseable JSON"
                        string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });

                        if (string.Equals(responseBody, "Email is not verified", StringComparison.OrdinalIgnoreCase))
                            await Navigation.PushAsync(new EmailVerificationPage(email_AddressEntry.Text));
                        else
                        {
                            // Use Newtonsoft Package to create the current User object and apply the json values to their session (Ignoring Null and Missing Values)
                            var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                            currentUser = JsonConvert.DeserializeObject<User>(responseBody, deserializationSettings);
                            currentUser.email_address = email_AddressEntry.Text;

                            // Uncomment to display current user's information to the screen
                            /*string hi = "UID: " + currentUser.uid + "\n" + "Email: " + currentUser.email_address + "\n" +
                                        "Credentials ID: " + currentUser.credentials_id + "\n" + "Name: " + currentUser.name + "\n" +
                                        "Birthday: " + currentUser.birthday + "\n" + "City: " + currentUser.city + "\n" +
                                        "State: " + currentUser.state + "\n" + "Gender: " + currentUser.gender + "\n" + "Major: " + currentUser.major;
                            await DisplayAlert("", hi, "OK");*/


                            // Navigate to the Home Page with Tab Group
                            Application.Current.MainPage = new TabMainPage();
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