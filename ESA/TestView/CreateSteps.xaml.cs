using ESA.Models.CustomRenderers;
using ESA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ESA.Models.CustomRenderers.CustomEditor;

namespace ESA.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSteps : ContentPage
    {
        public CustomWebview GetKeyPointsTextEditor { get; private set; }
        public bool WebViewLoaded;
        public CreateSteps()
        {
            InitializeComponent();
            GetKeyPointsTextEditor = TextEditor.FindByName<CustomWebview>("RichTextEditor");
            /* Subscribe to message "Completed" to signify text editor has finished loading
             * The message is sent from CustomWebviewRenderer class in ESA.Android when 
             * OnPageFinished function is loaded. 
             * */
            MessagingCenter.Subscribe<object>(this, "Completed", (sender) => {
                System.Diagnostics.Debug.WriteLine("Html text editor has finished loading");
                GetKeyPointsTextEditor.EvaluateJavaScriptAsync("GenerateList()");
                // Unsubscribe immediately to dispose of current subscription to prevent memory leak
                MessagingCenter.Unsubscribe<object>(this, "Completed");
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Database_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateKeyPoints());
        }
    }
}