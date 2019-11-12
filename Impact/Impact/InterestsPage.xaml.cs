using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace Impact
{
    public partial class InterestsPage : ContentPage
    {
        public InterestsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);

            var interestsList = new List<string>();
            interestsList.Add("Acting or Entertaining");
            interestsList.Add("Communication");
            interestsList.Add("Film");
            interestsList.Add("Problem Solving");
            interestsList.Add("Languages");
            interestsList.Add("Media");
            interestsList.Add("Social Justice");

            var interestsPicker = new Picker { Title = "Select an Interest", TitleColor = Color.Red };
            interestsPicker.ItemsSource = interestsList;

            var hobbiesList = new List<string>();
            hobbiesList.Add("Writing");
            hobbiesList.Add("Cooking");
            hobbiesList.Add("Photogrpahy");
            hobbiesList.Add("Painting");
            hobbiesList.Add("Video Games");
            hobbiesList.Add("Media");
            hobbiesList.Add("Social Justice");

            var hobbiesPicker = new Picker { Title = "Select a Hobby", TitleColor = Color.Red };
            hobbiesPicker.ItemsSource = hobbiesList;

        }

        private async void finishPage_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Not Implemented", "Does nothing for now", "OK");
        }
    }
}
