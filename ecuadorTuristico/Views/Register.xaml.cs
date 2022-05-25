using ecuadorTuristico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecuadorTuristico.Models;
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
            var GenderList = new List<string>
            {
                "Masculino",
                "Femenino",
                "Otros"
            };
            SelectGender.ItemsSource = GenderList;

        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(TxtUser.Text) || String.IsNullOrWhiteSpace(TxtEmail.Text) || String.IsNullOrWhiteSpace(TxtPassword.Text) || String.IsNullOrWhiteSpace(TxtConfirmPassword.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
            }
            else
            {
                DisplayAlert("AVISO", "Cuenta creada correctamente", "OK");
            }
            
        }

        private async void BtnReturn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}