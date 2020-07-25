
using ESA.Models.Model;
using ESA.Models.CustomRenderers;
using ESA.ViewModels;
using ESA.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyPointsView : ContentView
    {
        public DetailsViewModel procedureViewModel;
        public int currentPointNumber;

        public KeyPointsView() { InitializeComponent(); }

        public KeyPointsView(DetailsViewModel pvm)
        {
            InitializeComponent();
            procedureViewModel = pvm;
            
            foreach(KeyPoint kp in procedureViewModel.Procedure.KeyPoints)
            {
                kp.HasDiagram = kp.DiagramURL != "" || kp.DiagramURL != null;
            }

            BindingContext = procedureViewModel.Procedure;

            
            currentPointNumber = 1;
        }

        private void KeyPointsContent_TapEventHandler(object sender, EventArgs e)
        {
            // get the current step
            //KeyPoint prevStep = procedureViewModel.Procedure.KeyPoints.ElementAt(this.currentPointNumber);
            // get the step clicked
            StackLayout currPointParentLayout = ((StackLayout)sender);
            KeyPoint currPoint = (KeyPoint)currPointParentLayout.BindingContext;
            StackLayout currPointGrandparent = (StackLayout)currPointParentLayout.Parent;
            this.currentPointNumber = currPoint.Number;

            // get the current point layout
            //StackLayout currPointLayout = ((StackLayout)pointsLayout.Children.ElementAt(currStep.Number));
            //StackLayout currentPointContentLayout = ((StackLayout)currPointLayout.Children.First());

            // Diagram drop down
            if (currPoint.HasDiagram)
            {
                ImageButton pointDiagramBtn = ((ImageButton)currPointGrandparent.Children.Last());
                bool visibility = true;

                if (pointDiagramBtn.IsVisible)
                {
                    // Rotate expandable icon
                    currPointParentLayout.Children.Last().RotateTo(0, 500, Easing.CubicInOut);
                    visibility = false;
                }
                else
                {
                    // Rotate expandable icon
                    currPointParentLayout.Children.Last().RotateTo(-180, 500, Easing.CubicInOut);
                }
                pointDiagramBtn.IsVisible = visibility;
            }
        }

        private void DiagramThumbnail_Clicked(object sender, EventArgs e)
        {
            procedureViewModel.VideoName = "Brain_Eyes_Vid.mp4";
            procedureViewModel.VideoIsProcedure = false;
            Navigation.PushAsync(new VideoPage(procedureViewModel));
        }

        private void RelatedProcedureButton_Clicked(object sender, EventArgs e)
        {
            int procedureId = procedureViewModel.Procedure.KeyPoints.First(k => k.Point == ((Label)((StackLayout)((StackLayout)((CustomButton)sender).Parent).Children.First()).Children.ElementAt(1)).Text).Procedure.Id;
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                    Navigation.PushAsync(new DetailsPage(procedureViewModel.Procedure));
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