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
            profilePage_myImage.Source = App.currentUser.imageUrl;
            profilePage_email_address.Text = "Email Address: " + App.currentUser.email_address;
            profilePage_name.Text = App.currentUser.name;
            profilePage_bio.Text = App.currentUser.bio;
            profilePage_age.Text = (DateTime.Today.Year - App.currentUser.birthday.Year).ToString();
            profilePage_birthday.Text = "Birth date: " + App.currentUser.birthday.Date.ToShortDateString();
            profilePage_city.Text = App.currentUser.city;
            profilePage_state.Text = App.currentUser.state;
            profilePage_gender.Text = App.currentUser.gender;
            profilePage_major.Text = App.currentUser.major;
            profilePage_userType.Text = determineUserType(App.currentUser.user_type);
            profilePage_interest1.Text = App.currentUser.interest1;
            profilePage_interest2.Text = App.currentUser.interest2;
            profilePage_interest3.Text =  App.currentUser.interest3;
            profilePage_hobby1.Text = App.currentUser.hobby1;
            profilePage_hobby2.Text = App.currentUser.hobby2;
            profilePage_hobby3.Text = App.currentUser.hobby3;
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

        private string determineUserType(int userType)
        {
            if (userType == -1)
                return "Administration";
            else if (userType == 0)
                return "Student";
            else
                return "Mentor";
        }
        private async void Settings_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Icon Clicked", "You clicked settings", "OK");
            //await Navigation.PushAsync(new Settings());
        }

        private void logout_ButtonClicked(object sender, EventArgs e)
        {
            App.instance.logoutCurrentUser();
        }

        private async void Edit_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Icon Clicked", "You clicked edit", "OK");
        }
    }
}