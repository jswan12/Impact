using Rg.Plugins.Popup.Services;
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
            await PopupNavigation.PushAsync(new MatchesPage());
        }
    }
}