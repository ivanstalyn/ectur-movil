using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ecuadorTuristico.Models;
using ecuadorTuristico.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ecuadorTuristico.Views;

namespace ecuadorTuristico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            ChangeData();
        }

        protected async void ChangeData()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://ectur.php.ec/producto"),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<producto>>(content);

                ListProducts.ItemsSource = res;
            }
        }

        private void ProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (producto)e.SelectedItem;
            var id = Obj.id.ToString();
            var nombre = Obj.nombre.ToString();
            var precio = Obj.precio.ToString();
            var descripcion = Obj.descripcion.ToString();
            var fchInicio = Obj.fechaInicioEvento.ToString();
            var fchFin = Obj.fechaFinalEvento.ToString();
            var image = Obj.foto.ToString();
            int ID = Convert.ToInt32(id);
            try
            {
                Navigation.PushAsync(new AcquireProduct(ID, nombre, precio, descripcion, fchInicio, fchFin, image));
            }
            catch (Exception)
            {

            }

        }
    }
}