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
    public partial class HomePage : ContentPage
    {
        HomePagePostViewModel homePagePostvm;
        public HomePage()
        {
            InitializeComponent();
            homePagePostvm = new HomePagePostViewModel();
            BindingContext = homePagePostvm;
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as HomePagePost;
            await Navigation.PushAsync(new HomePagePostDetailPage(mydetails.universityImageUrl, mydetails.posterName, mydetails.postTitle, mydetails.postBody));
        }
    }
}