using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecuadorTuristico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcquireProduct : ContentPage
    {
        public int IdProduct;
        public string urlImage;
        public AcquireProduct(int Id, string nombre, string precio, string descripcion, string fchInicio, string fchFin, string image)
        {
            InitializeComponent();
            IdProduct = Id;
            ImageProduct.Source = image;
            lblNombre.Text = nombre;
            lblDescripcion.Text = descripcion;
            lblPrecio.Text = precio;
            lblFchInicio.Text = fchInicio;
            lblFchFin.Text = fchFin;
        }

        private void BtnReversar_Clicked(object sender, EventArgs e)
        {

        }
    }
}