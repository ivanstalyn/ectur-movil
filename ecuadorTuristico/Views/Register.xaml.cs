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
    public partial class Register : ContentPage
    {
        public Register()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtUser.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtPassword.Text) || String.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
            }
            else
            {
                DisplayAlert("AVISO", "Cuenta creada correctamente", "OK");
            }
            
        }

        private async void btnReturn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}