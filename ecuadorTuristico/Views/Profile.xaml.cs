using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ecuadorTuristico.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public string idUserP;
        public Profile()
        {
            InitializeComponent();
            ExtraerDatos();
            idUserP = Preferences.Get("idUser", "1");
        }

        private async void BtnTomarFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "PhotoProfil.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            
            ImageProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
            
            var x = file.GetStream();
            var bytes = new byte[x.Length];
            await x.ReadAsync(bytes, 0, (int)x.Length);
            string fotobase64 = System.Convert.ToBase64String(bytes);

            //ImageProfile.Source = System.Convert.FromBase64String(fotobase64);

        }

        private async void BtnSubirFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });
            if (file == null)
                return;
            ImageProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        
        private async void ExtraerDatos()
        {
            idUserP = Preferences.Get("idUser", "1");
            string url = "http://ectur.php.ec/usuario/usuario/" + idUserP;
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            string res = await client.GetStringAsync(url);
            var result = JObject.Parse(res);
            TxtUsuario.Text = result["username"].ToString();
            TxtEmail.Text = result["email"].ToString();
            TxtPassword.Text = result["password"].ToString();
            TxtNombres.Text = result["nombres"].ToString();
            TxtApellidos.Text = result["apellidos"].ToString();
            TxtTelefono.Text = result["telefono"].ToString();
            TxtIdentificacion.Text = result["identificacion"].ToString();
            TxtFechaNac.Text = result["fechaNacimiento"].ToString();
            ImageProfile.Source = result["foto"].ToString();
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //if(await ValidarFormulario())
                //{
                await DisplayAlert("AVISO", "Desea crear su cuenta?", "SI", "NO");
                usuario user = new usuario
                {
                    username = TxtUsuario.Text,
                    password = TxtPassword.Text,
                    email = TxtEmail.Text,
                    nombres = TxtNombres.Text,
                    apellidos = TxtApellidos.Text,
                    telefono = TxtTelefono.Text,
                    identificacion = TxtIdentificacion.Text,
                    fechaNacimiento = TxtFechaNac.Text,
                    rol = new rol { id = 2 },//2
                    genero = new genero { id = 5 },//5
                    empresa = new empresa { id = 1 }//1
                };
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://ectur.php.ec");
                var json = JsonConvert.SerializeObject(user);
                StringContent contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("/usuario/actualizarUsuario/"+Convert.ToInt32(idUserP), contentJson);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("AVISO", "Datos actualizados correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("AVISO", "Error", "OK");
                }

                //}
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }

        }
    }
}