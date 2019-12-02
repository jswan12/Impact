using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

        }
        private void LogoutPressed(object sender,EventArgs e) {

          App.instance.logoutCurrentUser();
        }

        private async void ReportPressed(object sender, EventArgs e)
        {
            await DisplayAlert("Report", "To report misconduct, please email administration.", "OK");
        }
        private async void LegalPressed(object sender, EventArgs e)
        {
            await DisplayAlert("Legal and Policies", "Impact is not liable for any misconduct or misfortune that arises from communication." +
                "If you are a victim of misconduct, please refer to our Report page ", "OK");
        }
        private async void ChangePasswordPressed(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ChangePassword()); 
        }





    }
}
