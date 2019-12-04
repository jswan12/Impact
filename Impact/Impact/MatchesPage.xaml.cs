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
        ObservableCollection<User> trends = new ObservableCollection<User>() {
                new User() { name = "Chen Wang", city = "Baton Rouge", state = "Louisiana", interest1 = "Genetics", interest2 = "Robotics", interest3 = "Number Theory", hobby1 = "Exercising", hobby2 = "Robotics", hobby3 = "Cooking", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/chen.wang.png" },
                new User() { uid = 56, name = "Anas Mahmoud", city = "Baton Rouge", state = "Louisiana", interest1 = "Nanotechnology", interest2 = "Genetics", interest3 = "Robotics", hobby1 = "Writing", hobby2 = "Photography", hobby3 = "Painting", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/anas.mahmoud.jpg" },
                new User() { name = "Gerald Baumgartner", city = "Baton Rouge", state = "Louisiana", interest1 = "Robotics", interest2 = "Logic", interest3 = "Agricultural Science", hobby1 = "Chess", hobby2 = "Painting", hobby3 = "Cooking", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/gerald.baumgartner.jpg" },
                new User() { uid = 54, name = "Jinwei Ye", city = "Baton Rouge", state = "Louisiana", interest1 = "Logic", interest2 = "Robotics", interest3 = "Nanotechnology", hobby1 = "Cooking", hobby2 = "Exercising", hobby3 = "Writing", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jinwei.ye.png" },
                new User() { uid = 55, name = "Sukhamay Kundu", city = "Baton Rouge", state = "Louisiana", interest1 = "Robotics", interest2 = "Nanotechnology", interest3 = "Logic", hobby1 = "Cooking", hobby2 = "Video Games", hobby3 = "Exercising", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/sukhamay.kundu.jpg" },
                new User() { name = "Jianhua Chen", city = "Baton Rouge", state = "Louisiana", interest1 = "Logic", interest2 = "Nanotechnology", interest3 = "Space research", hobby1 = "Chess", hobby2 = "Photography", hobby3 = "Writing", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jianhua.chen.jpg" },
                new User() { name = "Golden Richard III", city = "Baton Rouge", state = "Louisiana", interest1 = "Agricultural Science", interest2 = "Nanotechnology", interest3 = "Space research", hobby1 = "Cooking", hobby2 = "Video Games", hobby3 = "Exercising", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/golden2.jpg" },
                new User() { name = "Evangelos Triantaphyllou", city = "Baton Rouge", state = "Louisiana", interest1 = "Robotics", interest2 = "Agricultural Science", interest3 = "Number Theory", hobby1 = "Cooking", hobby2 = "Video Games", hobby3 = "Exercising", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/evangelos.triantaphyllou.jpg" },
                new User() { uid = 52, name = "Jian Zhang", city = "Baton Rouge", state = "Louisiana", interest1 = "Space research", interest2 = "Nanotechnology", interest3 = "Genetics", hobby1 = "Cooking", hobby2 = "Video Games", hobby3 = "Painting", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jian.zhang.jpg" },
                new User() { name = "Patti Aymond", city = "Baton Rouge", state = "Louisiana", interest1 = "Robotics", interest2 = "Nanotechnology", interest3 = "Logic", hobby1 = "Video Games", hobby2 = "Cooking", hobby3 = "Chess", imageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/aymond.patti.jpg" }
        };

        public MatchesPage()
        {
            InitializeComponent();
            GetRecommendedMentors();
        }

        protected async void GetRecommendedMentors()
        {
            //-------Genetics, Nanotechnology, Logic  ||  Cooking, Video Games, Exercising-------
            mentorListView.ItemsSource = trends;
        }

        public async void OnButtonClicked(Object sender, EventArgs e)
        {
            try
            {
                User selectedUser = mentorListView.CurrentItem as User;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsync(new Uri(string.Format("https://asp-impact.azurewebsites.net/api/Connections?m_id=" + selectedUser.uid + "&s_id=" + App.currentUser.uid)), null);
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        await DisplayAlert("Request Sent!", "Your request has been sent to " + selectedUser.name, "OK");
                        trends.Remove(selectedUser);
                    }
                    else
                        await DisplayAlert("Error", responseBody, "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void Close(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}