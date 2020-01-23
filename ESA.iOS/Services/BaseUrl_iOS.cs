using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESA.iOS.Services;
using ESA.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl_iOS))]
namespace ESA.iOS.Services
{
    public class BaseUrl_iOS : IBaseUrl
    {
        public string Get()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}