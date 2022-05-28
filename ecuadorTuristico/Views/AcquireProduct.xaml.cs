using ecuadorTuristico.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcquireProduct : ContentPage
    {
        public int IdProduct;
        public string urlImage;
        public string idUserA;
        public AcquireProduct(int Id, string nombre, string precio, string descripcion, string fchInicio, string fchFin, string image)
        {
            InitializeComponent();
            idUserA = Preferences.Get("idUser", "1");
            IdProduct = Id;
            ImageProduct.Source = image;
            lblNombre.Text = nombre;
            lblDescripcion.Text = descripcion;
            lblPrecio.Text = precio;
            lblFchInicio.Text = fchInicio;
            lblFchFin.Text = fchFin;
        }

        private async void BtnReversar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("AVISO", "Desea adquirir este paquete turistico?", "SI", "NO");
            solicitud user = new solicitud
            {
                mensaje = "Paquete en revision",
                usuario = new usuario { id = Convert.ToInt32(idUserA) },
                producto = new producto { id = IdProduct},

            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://ectur.php.ec");
            var json = JsonConvert.SerializeObject(user);
            StringContent contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/solicitud", contentJson);
            await DisplayAlert("AVISO", "Paquete turistico adquirido", "OK");
        }
    }
}