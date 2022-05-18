using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ecuadorTuristico.Droid;
using ecuadorTuristico.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(MessageTOAST))]
namespace ecuadorTuristico.Droid
{
    class MessageTOAST : MessageT
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}