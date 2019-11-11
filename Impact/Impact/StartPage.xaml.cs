using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Impact
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this.StartPage_content, false);
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }

}