using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MatchesPage
    {
        public MatchesPage()
        {
            InitializeComponent();
            GetRecommendedMentors();
        }

        protected async void GetRecommendedMentors()
        {
            /*            try
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                HttpResponseMessage response = await client.GetAsync(new Uri(string.Format("https://asp-impact.azurewebsites.net/api/HomePost?uid=" + App.currentUser.uid)));
                                string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                                {
                                    var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };*/
            //HasUnevenRows = "True" ItemTapped = "OnItemSelected" SeparatorVisibility = "None" IsPullToRefreshEnabled = "True"
            ObservableCollection<MatchesPageMentor> trends = new ObservableCollection<MatchesPageMentor>() { //JsonConvert.DeserializeObject<List<MatchesPageMentor>>(responseBody, deserializationSettings)
            new MatchesPageMentor() { User_Name = "Abby Richard", Location = "Hampton", Details = "So many details", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Bobby Snow", Location = "Georgia", Details = "Not so many details", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Cathy Noble", Location = "New York", Details = "Yikes", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Darrious Blanchard", Location = "Destrehan", Details = "Hello this is my bio", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Frank Gore", Location = "Buffalo", Details = "What are you looking at", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Heather Wise", Location = "New Mexico", Details = "Yeah im cool", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "John Mappple", Location = "Laplace", Details = "Do your work bro", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Kayla Lott", Location = "Texas", Details = "I can't help you study, sorry", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Pablo Sinco", Location = "Canada", Details = "Catch me outside", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" },
                    new MatchesPageMentor() { User_Name = "Samantha Breaux", Location = "Vermont", Details = "Rant to me!!", ImageUrl = "https://content.haycdn.com/mgen/options:FNM363_606_LSU.jpg?is=700,700,0xffffff" }
            };
            mentorListView.ItemsSource = trends;
/*                    }
                    else
                        await DisplayAlert("Error", responseBody, "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }

        public async void OnButtonClicked(Object sender, EventArgs e)
        {
            await DisplayAlert("Request Sent!", "Your request has been sent to the user.", "OK");
        }

        private async void Close(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}