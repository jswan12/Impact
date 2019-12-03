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
        ObservableCollection<MatchesPageMentor> trends;
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
                                                                                //Robotics, Space research, Genetics, Nanotechnology, Agricultural Science, Number Theory, Logic
                                                                                //Writing, Cooking, Photography, Painting, Video Games, Exercising, Chess
                                                                                //-------Nanotechnology, Logic, Cooking, Video Games, Exercising-------
            ObservableCollection<MatchesPageMentor> trends = new ObservableCollection<MatchesPageMentor>() { //JsonConvert.DeserializeObject<List<MatchesPageMentor>>(responseBody, deserializationSettings)
            new MatchesPageMentor() { User_Name = "Chen Wang", Location = "Baton Rouge", Details = "Genetics, Robotics, Number Theory, Exercising, Robotics, Cooking", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/chen.wang.png" },
            new MatchesPageMentor() { User_Name = "Anas Mahmoud", Location = "Baton Rouge", Details = "Nanotechnology,  Genetics, Robotics,  Writing, Photography, Painting", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/anas.mahmoud.jpg" },
            new MatchesPageMentor() { User_Name = "Gerald Baumgartner", Location = "Baton Rouge", Details = "Robotics, Logic, Agricultural Science, Chess, Painting, Cooking", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/gerald.baumgartner.jpg" },
            new MatchesPageMentor() { User_Name = "Nathan Brener", Location = "Baton Rouge", Details = "Logic, Robotics, Nanotechnology, Cooking, Exercising, Writing", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/nathan.brener.jpg" },
            new MatchesPageMentor() { User_Name = "Sukhamay Kundu", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic, Cooking, Video Games, Exercising", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/sukhamay.kundu.jpg" },
            new MatchesPageMentor() { User_Name = "Jianhua Chen", Location = "Baton Rouge", Details = "Logic, Nanotechnology,  Space research, Chess, Photography, Writing", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jianhua.chen.jpg" },
            new MatchesPageMentor() { User_Name = "Golden Richard III", Location = "Baton Rouge", Details = "Agricultural Science, Nanotechnology, Space research, Cooking, Video Games, Exercising", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/golden2.jpg" },
            new MatchesPageMentor() { User_Name = "Evangelos Triantaphyllou", Location = "Baton Rouge", Details = "Robotics, Agricultural Science, Number Theory, Cooking, Video Games, Exercising", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/evangelos.triantaphyllou.jpg" },
            new MatchesPageMentor() { User_Name = "Jian Zhang", Location = "Baton Rouge", Details = "Space research, Nanotechnology, Genetics, Cooking, Video Games, Painting", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jian.zhang.jpg" },
            new MatchesPageMentor() { User_Name = "Patti Aymond", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Video Games, Logic, Cooking, Chess, ", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/aymond.patti.jpg" }
                    
                    //new MatchesPageMentor() { User_Name = "William Duncan", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/william.duncan.jpg" },
                    //new MatchesPageMentor() { User_Name = "Kisung Lee", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic ", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/kisung.lee.jpg" },
                    //new MatchesPageMentor() { User_Name = "Konstantin Busch", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic ", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/konstantin.busch.jpg" },
                    //new MatchesPageMentor() { User_Name = "Supratik Mukhopadhyay", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic ", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/supratik.mukhopadhyay.jpg" },
                    //new MatchesPageMentor() { User_Name = "Seungjong Park", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic ", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/seungjong.park.jpg" },
                    //new MatchesPageMentor() { User_Name = "Qingyang Wang", Location = "Baton Rouge", Details = "Robotics, Nanotechnology, Logic", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/qingyang.wang.jpg" },
                    //new MatchesPageMentor() { User_Name = "Mingxuan Sun", Location = "Baton Rouge", Details = "Rant to me!!", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/mingxuan.sun.jpg" },
                    //new MatchesPageMentor() { User_Name = "Rahul Shah", Location = "Baton Rouge", Details = "Rant to me!!", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/rahul.shah.jpg" },
                    //new MatchesPageMentor() { User_Name = "Feng Chen", Location = "Baton Rouge", Details = "Rant to me!!", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/feng.chen.jpg" },
                    //new MatchesPageMentor() { User_Name = "Doris Carver", Location = "Baton Rouge", Details = "Rant to me!!", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/doris.carver2.jpg" },
                    //new MatchesPageMentor() { User_Name = "Jinwei Ye", Location = "Baton Rouge", Details = "Rant to me!!", ImageUrl = "https://www.lsu.edu/eng/cse/people/faculty/photos/jinwei.ye.png" }
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
            MatchesPageMentor bob = mentorListView.CurrentItem as MatchesPageMentor;
            await DisplayAlert("Request Sent!", "Your request has been sent to " + bob.User_Name, "OK");
            trends.Remove(bob);
        }

        private async void Close(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}