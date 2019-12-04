using Impact;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Impact
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupsPage : ContentPage
    {
        public GroupsPage()
        {
            InitializeComponent();
        }

        private async void mainGroup1_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainGroup());
        }

        private async void mainGroup2_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FocusGroup());
        }

        async private void mainGroup3_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}