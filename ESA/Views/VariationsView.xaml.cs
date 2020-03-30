using ESA.Models;
using ESA.Models.CustomRenderers;
using ESA.Models.Model;
using ESA.ViewModels;
using ESA.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VariationsView : ContentView
    {
        public DetailsViewModel procedureViewModel;

        public VariationsView() { InitializeComponent(); }

        public VariationsView(DetailsViewModel pvm)
        {
            InitializeComponent();
            procedureViewModel = pvm;
            BindingContext = procedureViewModel.Procedure;
        }

        private void RelatedProcedureButton_Tapped(object sender, EventArgs e)
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                    Navigation.PushAsync(new DetailsPageDesktop(procedureViewModel.Procedure));
                    break;
                case TargetIdiom.Phone:
                    Navigation.PushAsync(new DetailsPage(procedureViewModel.Procedure));
                    break;
                case TargetIdiom.Tablet:
                    break;
            }
        }

        private void RelatedProcedureButton_Clicked(object sender, EventArgs e)
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                    Navigation.PushAsync(new DetailsPageDesktop(procedureViewModel.Procedure));
                    break;
                case TargetIdiom.Phone:
                    Navigation.PushAsync(new DetailsPage(procedureViewModel.Procedure));
                    break;
                case TargetIdiom.Tablet:
                    break;
            }
        }
    }
}