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
    public partial class ConnectionsPage : ContentPage
    {
        ConnectionsPageUsersViewModel connectionsPageUsersvm;
        public ConnectionsPage()
        {
            InitializeComponent();
            connectionsPageUsersvm = new ConnectionsPageUsersViewModel();
            BindingContext = connectionsPageUsersvm;
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