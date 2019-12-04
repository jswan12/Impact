using Impact;
using Newtonsoft.Json;
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
    public partial class GroupsPage : ContentPage
    {
        public GroupsPage()
        {
            InitializeComponent();
            GetMentorForums();
            GetFocusGroups();

            listMentorForums.RefreshCommand = new Command(() => {
                GetMentorForums();
                listMentorForums.IsRefreshing = false;
            });

            listFocusGroups.RefreshCommand = new Command(() => {
                GetFocusGroups();
                listFocusGroups.IsRefreshing = false;
            });
        }

        protected async void GetMentorForums()
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
                        listMentorForumsNoItems.IsVisible = false;
                        listMentorForums.ItemsSource = trends;
                    }
                    else
                    {
                        if (responseBody.Equals("No Active Connections"))
                        {
                            listMentorForums.ItemsSource = trends;
                            listMentorForums.SeparatorColor = Color.Transparent;
                            listMentorForumsNoItems.IsVisible = true;
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

        protected async void GetFocusGroups()
        {
            listFocusGroups.SeparatorColor = Color.Transparent;
            listFocusGroupsNoItems.IsVisible = true;
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as User;
            if (mydetails.uid == 56)//Nash
                await Navigation.PushAsync(new MainGroup());
            else if(mydetails.uid == 52)//zhang
                await Navigation.PushAsync(new FocusGroup());
            else if(mydetails.uid == 54)//yee
                await Navigation.PushAsync(new FocusGroup());
            else
                await Navigation.PushAsync(new FocusGroup());
        }
    }
}