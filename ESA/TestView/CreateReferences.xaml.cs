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
    public partial class CreateReferences : ContentPage
    {
        public CreateReferences()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listEditor.FindByName<StackLayout>("AddList").Children.FirstOrDefault().Focus();
        }
    }
}