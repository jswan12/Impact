using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Net.Http;

namespace Impact
{
    public partial class App : Application
    {
        public static User currentUser;
        //public static HttpClient client = new HttpClient();

        static LocalDatabase database;
        public static LocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LocalDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Impact-LocalDatabase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage()) { BarBackgroundColor = Color.Orange, BarTextColor = Color.White };

            //MainPage = new TabMainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
