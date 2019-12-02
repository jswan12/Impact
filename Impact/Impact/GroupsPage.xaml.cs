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

        async private void mainGroup2_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }

        async private void mainGroup3_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }

        async private void subGroupA_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }

        async private void subGroupB_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }

        async private void subGroupC_ButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}