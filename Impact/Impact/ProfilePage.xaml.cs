using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            profilePage_uid.Text = "UID: " + App.currentUser.uid.ToString();
            profilePage_email_address.Text = "Email Address: " + App.currentUser.email_address;
            profilePage_credentials_id.Text = "Credentials ID: " + App.currentUser.credentials_id.ToString();
            profilePage_name.Text = "Name: " + App.currentUser.name;
            profilePage_birthday.Text = "Birthday: " + App.currentUser.birthday.ToString();
            profilePage_city.Text = "City: " + App.currentUser.city;
            profilePage_state.Text = "State: " + App.currentUser.state;
            profilePage_gender.Text = "Gender: " + App.currentUser.gender;
            profilePage_major.Text = "Major: " + App.currentUser.major;
        }

/*        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetUsersAsync();
        }*/

        public void OnButtonClicked(object sender, EventArgs e)
        {
            // This is for local database
            /*if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(emailEntry.Text))
            {
                await App.Database.SaveUserAsync(new User
                {
                    name = nameEntry.Text,
                    email_address = emailEntry.Text
                });

                nameEntry.Text = emailEntry.Text = string.Empty;
                listView.ItemsSource = await App.Database.GetUsersAsync();
            }*/
        }
        private async void Settings_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }

        private void logout_ButtonClicked(object sender, EventArgs e)
        {
            App.instance.logoutCurrentUser();
        }
    }
}