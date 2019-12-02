using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
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
    public partial class NewPostPopUp
    {
        public NewPostPopUp()
        {
            InitializeComponent();
            TitleEntry.ReturnCommand = new Command(() => BodyEntry.Focus());
            newPostPopUp_myImage.Source = App.currentUser.imageUrl;
            newPostPopUp_posterName.Text = App.currentUser.name;
        }
        private void TitleEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TitleEntry.Text) && !string.IsNullOrEmpty(BodyEntry.Text))
                PostButton.IsEnabled = true;
            else if (string.IsNullOrEmpty(TitleEntry.Text) || string.IsNullOrEmpty(BodyEntry.Text))
                PostButton.IsEnabled = false;
        }

        private async void Cancel_ButtonClicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }

        private async void Post_ButtonClicked(object sender, EventArgs e)
        {
            HomePagePost newPost = new HomePagePost()
            {
                creator_uid = App.currentUser.uid,
                posterName = App.currentUser.name,
                title = TitleEntry.Text,
                body = BodyEntry.Text,
                imageUrl = App.currentUser.imageUrl
            };
            await SendPostToDatabaseAsync(newPost);
        }

        private async Task SendPostToDatabaseAsync(HomePagePost newPost)
        {
            try
            {
                PostButton.IsEnabled = false;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var newPost_JSON = new StringContent(JsonConvert.SerializeObject(newPost), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(new Uri("https://asp-impact.azurewebsites.net/api/HomePost"), newPost_JSON);
                    string responseBody = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });

                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        await PopupNavigation.PopAsync();
                        
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
                PostButton.IsEnabled = true;
            }
        }
    }
}