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
    public partial class MatchesPage : ContentPage
    {
        MatchesPageMentorViewModel matchesPageMentorsvm;
        public MatchesPage()
        {
            InitializeComponent();
            matchesPageMentorsvm = new MatchesPageMentorViewModel();
            BindingContext = matchesPageMentorsvm;
        }

        public async void OnUserGestureRecognizerTapped(Object sender, EventArgs e)
        {
            var mydetails = e.ToString();
            //string detailString = mydetails.User_Name + "\n" + mydetails.Location + "\n" + mydetails.Details;
            await DisplayAlert("HI", mydetails, "OK");
        }

        public async void OnButtonClicked(Object sender, EventArgs e)
        {
            //var mydetails = e.CurrentItem as ConnectionsPageUser;
            //string detailString = mydetails.User_Name + "\n" + mydetails.Location + "\n" + mydetails.Details;
            await DisplayAlert("HI", "Does nothing as of now", "OK");
        }
    }
}