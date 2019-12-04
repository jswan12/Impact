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
    public partial class ConnectionsPage : ContentPage
    {
        public ConnectionsPage()
        {
            InitializeComponent();
            GetActive();
            GetRequested();

            listActive.RefreshCommand = new Command(() => {
                GetActive();
                listActive.IsRefreshing = false;
            });

            listRequested.RefreshCommand = new Command(() => {
                GetRequested();
                listRequested.IsRefreshing = false;
            });
        }

        protected async void GetActive()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ObservableCollection<User> trends = new ObservableCollection<User>();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(new Uri(string.Format("https://asp-impact.azurewebsites.net/api/Connections?uid=" + App.currentUser.uid)));
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        var deserializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
                        trends = new ObservableCollection<User>(JsonConvert.DeserializeObject<List<User>>(responseBody, deserializationSettings));
                        listActiveNoItems.IsVisible = false;
                        listActive.ItemsSource = trends;
                    }
                    else
                    {
                        if(responseBody.Equals("No Active Connections"))
                        {
                            listActive.ItemsSource = trends;
                            listActiveNoItems.IsVisible = true;
                        }
                        else
                            await DisplayAlert("Error", responseBody, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected async void GetRequested()
        {
            listRequestedNoItems.IsVisible = true;
        }

        private async void viewMentorsButtonClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PushAsync(new MatchesPage());
        }
    }
}