using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ecuadorTuristico.Views;

namespace ecuadorTuristico
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new Loggin();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
