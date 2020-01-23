using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Web;
using System.Text.RegularExpressions;
using ESA.Models.CustomRenderers;

namespace ESA.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateKeyPoints : ContentPage
    {
        public CustomWebview GetKeyPointsTextEditor { get; private set; }
        public CreateKeyPoints()
        {
            InitializeComponent();
            GetKeyPointsTextEditor = textEditor.FindByName<CustomWebview>("RichTextEditor");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Database_Clicked(object sender, EventArgs e)
        {
            var x = await GetKeyPointsTextEditor.EvaluateJavaScriptAsync("HtmlCode()");
            /* Parse the returned string into a regex to to check for unicode characters such as \U003C for "<" symbol
             * This will return the correct symbol for the corresponding unicode characters.
            **/
            Regex regex = new Regex(@"\\u([0-9a-z]{4})", RegexOptions.IgnoreCase);
            x = regex.Replace(x, match => char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)));
            /* After replacing unicode with corresponding symbol, unescape to remove escape character "\" from the string
             * Note: Regex.Escape seems to be done automatically. This will lead to the quote (") symbol to be escaped and
             * replaced with backslash quote (\") and will be included in the final result as a string.
            **/
            x = Regex.Unescape(x);
            System.Diagnostics.Debug.WriteLine(x);
            //await Navigation.PushAsync(new ShowHtml(x));
            await Navigation.PushAsync(new CreateVariations());
        }
        #region test html button
        private async void btnTest_Clicked(object sender, EventArgs e)
        {
            var x = await GetKeyPointsTextEditor.EvaluateJavaScriptAsync("HtmlCode()");
            /* Parse the returned string into a regex to to check for unicode characters such as \U003C for "<" symbol
             * This will return the correct symbol for the corresponding unicode characters.
            **/
            Regex regex = new Regex(@"\\u([0-9a-z]{4})", RegexOptions.IgnoreCase);
            x = regex.Replace(x, match => char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)));
            /* After replacing unicode with corresponding symbol, unescape to remove escape character "\" from the string
             * Note: Regex.Escape seems to be done automatically. This will lead to the quote (") symbol to be escaped and
             * replaced with backslash quote (\") and will be included in the final result as a string.
            **/
            x = Regex.Unescape(x);
            System.Diagnostics.Debug.WriteLine("First: " + x);
        }
        #endregion
    }

} 