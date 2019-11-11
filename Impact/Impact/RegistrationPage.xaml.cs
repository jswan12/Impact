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
            NavigationPage.SetHasBackButton(this, true);
            emailEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => nameEntry.Focus());
            nameEntry.ReturnCommand = new Command(() => birthdayEntry.Focus());
            birthdayEntry.ReturnCommand = new Command(() => addressEntry.Focus());
            addressEntry.ReturnCommand = new Command(() => genderEntry.Focus());
            genderEntry.ReturnCommand = new Command(() => majorEntry.Focus());
            majorEntry.ReturnCommand = new Command(() => interestsPage.Focus());
        }

        private async void interestsPage_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InterestsPage());
        }
      
    }
}
