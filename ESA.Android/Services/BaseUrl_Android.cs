using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ESA.Droid.Services;
using ESA.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_Android))]
namespace ESA.Droid.Services
{

    public class BaseUrl_Android : IBaseUrl
    {
        public string Get()
        {
            return "file:///android_asset/";
        }
    }
}