using ESA.Models;
using ESA.Models.CustomRenderers;
using ESA.Models.Model;
using ESA.ViewModels;
using ESA.Views.UWP_Views;
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
        DetailsViewModel procedureViewModel;
        public VariationsView(DetailsViewModel pvm)
        {
            InitializeComponent();
            procedureViewModel = pvm;
            BindingContext = procedureViewModel.Procedure;
        }

        private void RelatedProcedureButton_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetailsPage(procedureViewModel.Procedure));
        }

        private void RelatedProcedureButton_Clicked(object sender, EventArgs e)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                Navigation.PushAsync(new DetailsPage(procedureViewModel.Procedure));
            }
            else if (Device.Idiom == TargetIdiom.Desktop)
            {
                Navigation.PushAsync(new UWP_DetailsView(procedureViewModel.Procedure));
            }

            //Variation variation = procedureViewModel.Procedure.Variations[0];
            //int procedureId = variation.Procedure.First(rp => rp.ProcedureLink == ((CustomButton)sender).Text).Id;
            //Navigation.PushAsync(new DetailsPage(procedureId));
        }
    }
}