using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("idUser");
            var respuestaLogout = await DisplayAlert("Aviso!!", "Seguro desea cerrar sesion?", "Si", "No");
            if (respuestaLogout)
            {
                await Navigation.PopAsync();
            }
        }
    }
}