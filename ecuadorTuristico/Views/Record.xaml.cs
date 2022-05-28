using ecuadorTuristico.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        public string idUserS;
        public Record()
        {
            InitializeComponent();
            ChangeData();
            idUserS = Preferences.Get("idUser", "1");
        }

        protected async void ChangeData()
        {
            idUserS = Preferences.Get("idUser", "1");
            string url = "http://ectur.php.ec/solicitud/" + idUserS;
            var request = new HttpRequestMessage
            {
                
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
                
            };
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                solicitud res = JsonConvert.DeserializeObject<solicitud>(content);
                List<productoS> listaproductoS = res.respuestaSol;
                ListProducts.ItemsSource = listaproductoS;
            }
        }
    }
}