using ecuadorTuristico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecuadorTuristico.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

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

        private async Task<bool> ValidarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(TxtUser.Text) || String.IsNullOrWhiteSpace(TxtNombres.Text) || String.IsNullOrWhiteSpace(TxtApellidos.Text) ||
                String.IsNullOrWhiteSpace(TxtIdentificacion.Text) || String.IsNullOrWhiteSpace(TxtTelefono.Text) || String.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                var msj = "Complete los Campos";
                DependencyService.Get<MessageT>().LongAlert(msj);
                return false;
            }
                //Valida que el formato del correo sea valido
            bool isEmail = Regex.IsMatch(TxtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                var msj = "Ingrese un correo electrónico valido";
                DependencyService.Get<MessageT>().LongAlert(msj);
                return false;
            }

            if (TxtTelefono.Text.Length != 10 || TxtIdentificacion.Text.Length != 10)
            {
                var msj = "Número de celular o cedula incorrecto";
                DependencyService.Get<MessageT>().LongAlert(msj);
                return false;
            }

            if (!String.Equals(TxtPassword.Text, TxtConfirmPassword.Text))
            {
                var msj = "Contraseñas no coinciden";
                DependencyService.Get<MessageT>().LongAlert(msj);
                return false;
            }

            return true;
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            try{
                //if(await ValidarFormulario())
                //{
                    await DisplayAlert("AVISO", "Desea crear su cuenta??", "SI", "NO");
                    usuario user = new usuario {
                        username = TxtUser.Text,
                        password = TxtPassword.Text,
                        email = TxtEmail.Text,
                        nombres = TxtNombres.Text,
                        apellidos = TxtApellidos.Text,
                        telefono = TxtTelefono.Text,
                        identificacion = TxtIdentificacion.Text,
                        fechaNacimiento = "1998-01-01",
                        rol = new rol { id = 2 },//2
                        genero = new genero { id = 1},                       
                        empresa = new empresa { id = 1}//1
                    };

                    //Uri RequestUri = new Uri("http://ectur.php.ec/usuario/signup");
                    var client = new HttpClient();
                    client.BaseAddress = new Uri("http://ectur.php.ec");
                    var json = JsonConvert.SerializeObject(user);
                    StringContent contentJson = new StringContent(json, Encoding.UTF8, "application/json");              
                    HttpResponseMessage response = await client.PostAsync("/usuario/signup", contentJson);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        await DisplayAlert("AVISO", "Usuario creado correctamente", "OK");
                    }else
                {
                    await DisplayAlert("AVISO", "Error", "OK");
                }
                
                //}
            }
            catch(Exception ex){
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }

            }

        private async void BtnReturn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(false);
        }
    }
}