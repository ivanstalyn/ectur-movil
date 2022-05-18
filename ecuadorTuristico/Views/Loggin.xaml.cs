using ecuadorTuristico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loggin : ContentPage
    {
        public Loggin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void btnLoggin_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
        }

        private async void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register(), false);
        }
    }
}