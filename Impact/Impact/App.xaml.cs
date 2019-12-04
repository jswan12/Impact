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
        public static App instance;
        //public static HttpClient client = new HttpClient();

        //Hardcode for Messages to work
        public static string User = "User";

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
            instance = this;
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new Settings());
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

        public void ClearNavigationAndGoToPage(Page page)
        {
            MainPage = new NavigationPage(page) { BarBackgroundColor = Color.Orange, BarTextColor = Color.White };
        }

        public void logoutCurrentUser()
        {
            App.instance.ClearNavigationAndGoToPage(new LoginPage());
            currentUser = null;
        }
    }
}
