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
                var res = JsonConvert.DeserializeObject<List<Produtcs>>(content);

                ListProducts.ItemsSource = res;
            }
        }

        private void ProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Produtcs)e.SelectedItem;
            var item = Obj.Id.ToString();
            var item1 = Obj.Nombre.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new AcquireProduct(ID, item1));
            }
            catch (Exception)
            {

            }

        }
    }
}