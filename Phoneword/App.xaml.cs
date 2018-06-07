using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Phoneword
{
    public partial class App : Application
    {
        //This gets the list of phone numbers
        public static IList<string> PhoneNumbers { get; set; }

        public App()
        {
            //Initialising the app
            InitializeComponent();
            //Creates the list for the phone numbers
            PhoneNumbers = new List<string>();
            //Sets the main page to MainPage.xaml
            MainPage = new NavigationPage(new MainPage());
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