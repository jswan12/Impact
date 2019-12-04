using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        MessagePageConnectionsViewModel messagePageConnectionsvm;
        public MessagePage()
        {
            InitializeComponent();
            messagePageConnectionsvm = new MessagePageConnectionsViewModel();
            BindingContext = messagePageConnectionsvm;

            listMessages.RefreshCommand = new Command(() => {
                //Do your stuff.
                listMessages.IsRefreshing = false;
            });
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as MessagePageConnections;
            await Navigation.PushAsync(new MessagePageChat());
        }

    }

}