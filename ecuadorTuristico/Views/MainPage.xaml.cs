using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ecuadorTuristico
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage(string idUser)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            flyoutPage.listView.ItemSelected += OnItemSelected;
            Preferences.Set("idUser", idUser);
            if (Device.RuntimePlatform == Device.UWP)
            {
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ItemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                flyoutPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
