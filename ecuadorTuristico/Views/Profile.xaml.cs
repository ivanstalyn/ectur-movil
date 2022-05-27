using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ecuadorTuristico.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public int id;
        public Profile()
        {
            InitializeComponent();
            ExtraerDatos();
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
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            string res = await client.GetStringAsync("http://ectur.php.ec/usuario/usuario/2");
            var result = JObject.Parse(res);
            TxtUsuario.Text = result["username"].ToString();
            TxtCorreo.Text = result["email"].ToString();
            TxtPassword.Text = result["password"].ToString();
            TxtNombre.Text = result["nombres"].ToString();
            TxtApellido.Text = result["apellidos"].ToString();
            TxtTelefono.Text = result["telefono"].ToString();
            TxtCedula.Text = result["identificacion"].ToString();
            TxtFechaNac.Text = result["fechaNacimiento"].ToString();
            ImageProfile.Source = result["foto"].ToString();
        }
        
    }
}