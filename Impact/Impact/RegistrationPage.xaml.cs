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
            nameEntry.ReturnCommand = new Command(() => imageUrlEntry.Focus());
            imageUrlEntry.ReturnCommand = new Command(() => birthdayDatePicker.Focus());
			cityEntry.ReturnCommand = new Command(() => stateEntry.Focus());
            stateEntry.ReturnCommand = new Command(() => genderEntry.Focus());
            genderEntry.ReturnCommand = new Command(() => majorEntry.Focus());
		}

		private async void interestsPage_ButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new InterestsPage(new User{ uid = App.currentUser.uid, email_address = App.currentUser.email_address,  credentials_id = App.currentUser.credentials_id, name = nameEntry.Text, birthday = birthdayDatePicker.Date, city = cityEntry.Text, state = stateEntry.Text, gender = genderEntry.Text, major = majorEntry.Text, user_type = App.currentUser.user_type, imageUrl = imageUrlEntry.Text}));
        }

	}
}

