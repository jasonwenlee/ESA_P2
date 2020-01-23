using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Webkit;
using ESA.Droid.CustomRenderers;
using ESA.Models.CustomRenderers;
using ESA.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomWebview), typeof(CustomWebviewRenderer))]
namespace ESA.Droid.CustomRenderers
{
    public class CustomWebviewRenderer : WebViewRenderer
    {
        public CustomWebviewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            // Turn on Hardware acceleration depending of sdk version to improve webview performance
            if (Control != null)
            {
                if ((int)Build.VERSION.SdkInt >= 19)
                {
                    Control.SetLayerType(LayerType.Hardware, null);
                    Control.SetWebViewClient(new MyFormsWebViewClient());
                }
                else
                {
                    Control.SetLayerType(LayerType.Software, null);
                    Control.SetWebViewClient(new MyFormsWebViewClient());
                }
            }

            /* Set focus to editor in webview.
             * Note: Focus was also set to the editor in jquery rich text
            */
            if (Control.RequestFocus(FocusSearchDirection.Down))
            {
                InputMethodManager inputMethodManager = Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
                inputMethodManager.ShowSoftInput(Control.FindFocus(), ShowFlags.Implicit);
                inputMethodManager.ToggleSoftInput(ShowFlags.Implicit, HideSoftInputFlags.NotAlways);
            }
        }
        
        /* MyFormsWebViewClient class is used to check if the text editor has finished loading
         */
        internal class MyFormsWebViewClient : WebViewClient
        {
            // Eventhandler called when onpagefinished to signify text using MessagingCenter
            public event EventHandler FormLoadComplete = new EventHandler((sender, arg) => { 
                                                                            MessagingCenter.Send(sender, "Completed");
                                                                          });

            // Notify host application that a page has finished loading
            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                base.OnPageFinished(view, url);
                System.Diagnostics.Debug.WriteLine("Print");
                // Fire event handler
                FormLoadComplete(this, new EventArgs());
            }
        }
    }
}