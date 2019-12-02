using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Impact
{
    public partial class InterestsPage : ContentPage
    {
        User newUserInfo;
        public InterestsPage(User newUserInfo)
        {
            InitializeComponent();
            this.newUserInfo = newUserInfo;
            var interestsList = new List<string>();
            interestsList.Add("Robotics");
            interestsList.Add("Space research");
            interestsList.Add("Genetics");
            interestsList.Add("Nanotechnology");
            interestsList.Add("Agricultural Science");
			interestsList.Add("Number Theory");
			interestsList.Add("Logic");

            var interestsPicker = new Picker { Title = "Select an Interest", TitleColor = Color.Red };
            interestsPicker.ItemsSource = interestsList;

            var hobbiesList = new List<string>();
            hobbiesList.Add("Writing");
            hobbiesList.Add("Cooking");
            hobbiesList.Add("Photography");
            hobbiesList.Add("Painting");
            hobbiesList.Add("Video Games");
            hobbiesList.Add("Media");
            hobbiesList.Add("Social Justice");

            var hobbiesPicker = new Picker { Title = "Select a Hobby", TitleColor = Color.Red };
            hobbiesPicker.ItemsSource = hobbiesList;
        }

        private async void finishPage_ButtonClicked(object sender, EventArgs e)
        {
            newUserInfo.interest1 = interests1Picker.SelectedItem.ToString();
            newUserInfo.interest2 = interests2Picker.SelectedItem.ToString();
            newUserInfo.interest3 = interests3Picker.SelectedItem.ToString();
            newUserInfo.hobby1 = hobbies1Picker.SelectedItem.ToString();
            newUserInfo.hobby2 = hobbies2Picker.SelectedItem.ToString();
            newUserInfo.hobby3 = hobbies3Picker.SelectedItem.ToString();

            await createUserInfoAsync();
        }

        private async Task createUserInfoAsync()
        {
            try
            {
                //activityIndicator.IsRunning = true;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var newUserInfo_JSON = new StringContent(JsonConvert.SerializeObject(newUserInfo), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(new Uri("https://asp-impact.azurewebsites.net/api/User"), newUserInfo_JSON);
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });

                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        App.currentUser = JsonConvert.DeserializeObject<User>(responseBody, deserializationSettings);

                        //User Info Successfully added
                        App.instance.ClearNavigationAndGoToPage(new TabMainPage());
                    }
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
                //activityIndicator.IsRunning = false;
            }
        }
    }
}
