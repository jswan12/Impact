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
            profilePage_userType.Text = "user_type: " + App.currentUser.user_type;
            profilePage_interest1.Text = "interest1: " + App.currentUser.interest1;
            profilePage_interest2.Text = "interest2: " + App.currentUser.interest2;
            profilePage_interest3.Text = "interest3: " + App.currentUser.interest3;
            profilePage_hobby1.Text = "hobby1: " + App.currentUser.hobby1;
            profilePage_hobby2.Text = "hobby2: " + App.currentUser.hobby2;
            profilePage_hobby3.Text = "hobby3: " + App.currentUser.hobby3;
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