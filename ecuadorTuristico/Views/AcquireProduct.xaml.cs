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
        public AcquireProduct(int Id, string nombre)
        {
            InitializeComponent();
            IdProduct = Id;
            TxtNombre.Text = nombre;
        }
    }
}