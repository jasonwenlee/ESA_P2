﻿using ESA.Models.Model;
using ESA.Models.CustomRenderers;
using ESA.ViewModels;
using ESA.Views;
using ESA.Views.UWP_Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Expandable;
using ESA.MarkupExtensions;
using Windows.UI.Popups;

namespace ESA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepsView : ContentView
    {
        public DetailsViewModel procedureViewModel;

        public StepsView() { InitializeComponent(); }

        public StepsView(DetailsViewModel pvm)
        {
            InitializeComponent();

            procedureViewModel = pvm;
            BindingContext = procedureViewModel.Procedure;
        }

        private void DropdownContent_Tapped(object sender, EventArgs e)
        {
            // get first step using the number text associated with layout content
            Step chosenStep = procedureViewModel.Procedure.Steps.First(s => s.Number == int.Parse(((Label)((StackLayout)sender).Children.First()).Text));
            // get the expandable view
            ExtExpandableView extExpandableView = (ExtExpandableView)((StackLayout)((StackLayout)sender).Parent).Parent;
            // get the arrow image
            Image arrow = ((Image)((StackLayout)sender).Children.Last());
            // set expanded to chosen step has diagram
            if (!string.IsNullOrEmpty(chosenStep.DiagramURL))
            {
                extExpandableView.IsExpanded = !extExpandableView.IsExpanded;
                extExpandableView.ForceUpdateSize();

                if(extExpandableView.IsExpanded)
                {
                    arrow.RotateTo(180, 200, Easing.CubicInOut);
                }
                else
                {
                    arrow.RotateTo(0, 200, Easing.CubicInOut);
                }

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
            int procedureId = procedureViewModel.Procedure.Steps.First(s => s.Number == int.Parse(((Label)((StackLayout)((StackLayout)((CustomButton)sender).Parent).Children.First()).Children.First()).Text)).Procedure.Id;
            switch (Device.Idiom)
            {
                case TargetIdiom.Desktop:
                    Navigation.PushAsync(new UWP_DetailsPageV2(procedureViewModel.Procedure));
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