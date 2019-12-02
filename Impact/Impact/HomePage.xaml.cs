using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            HideElements();
            GetPosts();

            listHomePosts.RefreshCommand = new Command(() => {
                GetPosts();
                listHomePosts.IsRefreshing = false;
            });
        }

        private void HideElements()
        {
            int[] levels = { -1, 1 };
            if (!levels.Contains(App.currentUser.user_type))
                newPostStack.IsVisible = false;
        }

        protected async void GetPosts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(new Uri(string.Format("https://asp-impact.azurewebsites.net/api/HomePost?uid=" + App.currentUser.uid)));
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        ObservableCollection<HomePagePost> trends = new ObservableCollection<HomePagePost>(JsonConvert.DeserializeObject<List<HomePagePost>>(responseBody, deserializationSettings));
                        listHomePosts.ItemsSource = trends;
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

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as HomePagePost;
            await PopupNavigation.PushAsync(new HomePagePostDetailPage(mydetails.imageUrl, mydetails.posterName, mydetails.title, mydetails.body));
        }

        private async void NewPost_ButtonClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new NewPostPopUp());
        }
    }
}