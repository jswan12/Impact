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
    public partial class HomePagePostDetailPage : ContentPage
    {
        public HomePagePostDetailPage(string universityImageUrl, string posterName, string postTitle, string postBody)
        {
            InitializeComponent();
            universityImage.Source = new UriImageSource() {  Uri = new Uri(universityImageUrl) };
            this.posterName.Text = posterName;
            this.postTitle.Text = postTitle;
            this.postBody.Text = postBody;
        }
    }
}