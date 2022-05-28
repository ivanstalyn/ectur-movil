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
using Newtonsoft.Json.Linq;

namespace ecuadorTuristico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loggin : ContentPage
    {
        public int idUser;
        public Loggin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void BtnLoggin_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtUsuario.Text) || String.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
            }
            else
            {
                usuario initSession = new usuario()
                {
                    username = TxtUsuario.Text,
                    password = TxtPassword.Text
                };
                Uri urlRequets = new Uri("http://ectur.php.ec/usuario/signin");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(initSession);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(urlRequets, content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var result = JObject.Parse(resp);
                    string idUser = result["id"].ToString();
                    //idUser = Convert.ToInt32(id);
                    
                    await Navigation.PushAsync(new MainPage(idUser));
                    //await Navigation.PushModalAsync(new Profile(idUser));

                    TxtUsuario.Text = "";
                    TxtPassword.Text = "";                   
                    }
                    else
                    {
                        var msj = "Usuario o Contraseña Incorrectos!!";
                        DependencyService.Get<MessageT>().LongAlert(msj);
                    }
                }
            }

            private async void BtnCreateAccount_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new Register(), false);
            }
        }
    }
