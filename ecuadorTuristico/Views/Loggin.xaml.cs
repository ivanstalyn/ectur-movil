using ecuadorTuristico.Models;
using ecuadorTuristico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

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

        private async void BtnLoggin_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
            }
            else
            {
                /*
                Users initSession = new Users()
                {
                    username = txtEmail.Text,
                    password = txtPassword.Text
                };
                Uri urlRequets = new Uri("http://ectur.php.ec/usuario/signin");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(initSession);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlRequets, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                
                { 
                */
                    await Navigation.PushAsync(new MainPage());
                /*
                }
                else
                {
                    var msj = "Usuario o Contraseña Incorrectos!!";
                    DependencyService.Get<MessageT>().LongAlert(msj);
                } */
            }
        }

        private async void BtnCreateAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register(), false);
        }
    }
}