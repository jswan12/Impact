using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Impact
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            birthdayDatePicker.Date = new DateTime(1998, DateTime.Today.Month, DateTime.Today.Day);
            statePicker.ItemsSource = new string[] {"Alabama","Alaska","Arizona","Arkansas","California",
                                                     "Colorado","Connecticut","Delaware","Florida","Georgia",
                                                     "Hawaii","Idaho","Illinois", "Indiana","Iowa",
                                                     "Kansas","Kentucky","Louisiana","Maine","Maryland",
                                                     "Massachusetts","Michigan","Minnesota","Mississippi","Missouri",
                                                     "Montana", "Nebraska","Nevada","New Hampshire",
                                                     "New Jersey","New Mexico","New York","North Carolina","North Dakota",
                                                     "Ohio","Oklahoma","Oregon","Pennsylvania","Rhode Island",
                                                     "South Carolina","South Dakota","Tennessee","Texas","Utah",
                                                     "Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"};

            genderPicker.ItemsSource = new string[] {"Male","Female","Other/Prefer to not specify" };
            majorPicker.ItemsSource = new string[] {"Astronomy", "Biology", "Chemistry", "Computer Science", "Engineering", "Earth Sciences", "Health Sciences", "Information Technology" };
            nameEntry.ReturnCommand = new Command(() => imageUrlEntry.Focus());
            imageUrlEntry.ReturnCommand = new Command(() => birthdayDatePicker.Focus());
			cityEntry.ReturnCommand = new Command(() => statePicker.Focus());
		}

		private async void interestsPage_ButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new InterestsPage(new User{ uid = App.currentUser.uid, email_address = App.currentUser.email_address,  credentials_id = App.currentUser.credentials_id, name = nameEntry.Text, birthday = birthdayDatePicker.Date, city = cityEntry.Text, state = statePicker.SelectedItem.ToString(), gender = genderPicker.SelectedItem.ToString(), major = majorPicker.SelectedItem.ToString(), user_type = App.currentUser.user_type, imageUrl = string.IsNullOrEmpty(imageUrlEntry.Text) ? "https://icon-library.net/images/default-profile-icon/default-profile-icon-24.jpg" : imageUrlEntry.Text}));
        }

	}
}

