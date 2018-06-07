using System;
using Xamarin.Forms;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {
        //This creates a string varaible called "translatedNumber"
        string translatedNumber;
        //This ensures that MainPage can be used by more than just this class
        public MainPage()
        {
            //This initialises the app
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            //If there is a value in the user input, then it will give the user the option to call
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            //If no data is inputted, then it won't give the user the option to call
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
        //The program goes to this point if the user calls the translated number
        async void OnCall(object sender, EventArgs e)
        {
            //Displays an 'Are you sure?' box
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                //This adds the number to the call history
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    App.PhoneNumbers.Add(translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
            }
        }
        //The program moves on to this part
        async void OnCallHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallHistoryPage());
        }
    }
}