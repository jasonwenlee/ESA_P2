using ESA.iOS.CustomRenderers;
using ESA.Models.CustomRenderers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomWebview), typeof(CustomWebviewRenderer))]
namespace ESA.iOS.CustomRenderers
{
    public class CustomWebviewRenderer : WkWebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            //var webView = e.NewElement as CustomWebview;
            //if (webView != null)
            //    webView.EvaluateJavascript = (js) =>
            //    {
            //        return Task.FromResult(this.EvaluateJavascript(js));
            //    };
        }
    }
}