using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowHtml : ContentPage
    {
        private string v;

        public ShowHtml(string v)
        {
            InitializeComponent();
            var htmlText = v;
            var browser = new WebView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            var html = new HtmlWebViewSource
            {
                Html = htmlText
            };
            browser.Source = html;
            displayHtml.Children.Add(browser);

            // String below will be displayed as html without performing regex.unescape
            string checkText = "<div style=\\\"text-align: center;\\\"><b><i>a</i></b></div>";
        }

        private async void Database_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateHistory());
        }
    }
}