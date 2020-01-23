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
    public partial class CreateProcDescription : ContentPage
    {
        public CreateProcDescription()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateSteps());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DescriptionEditor.HeightRequest = Application.Current.MainPage.Height;
            TitleEntry.Focus();
        }
    }
}