﻿using ESA.Models.Model;
using ESA.ViewModels;
using ESA.Views;
using ESA.Views.UWP_Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ESA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        MainViewModel mainViewModel;
        AzureProceduresViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            // MainViewModel
            mainViewModel = new MainViewModel();
            BindingContext = viewModel = new AzureProceduresViewModel();

            if (Device.Idiom == TargetIdiom.Phone)
            {
            }
            else if (Device.Idiom == TargetIdiom.Desktop)
            {
                mainStackLayout.Margin = new Thickness(450, 40);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private async void MainListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var proc = e.SelectedItem as Procedure;
            if (e.SelectedItem == null) return;
            var test = proc.Steps;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                await Navigation.PushAsync(new DetailsPage(proc));
                ((ListView)sender).SelectedItem = null;
            }
            else if (Device.Idiom == TargetIdiom.Desktop)
            {
                //await Navigation.PushAsync(new UWP_DetailsView(proc));
                await Navigation.PushAsync(new UWP_DetailsPageV2(proc));
                //await Navigation.PushAsync(new UWP_DetailsPageV3(proc));
                //await Navigation.PushAsync(new UWP_DetailsPageV4(proc));
                ((ListView)sender).SelectedItem = null;
            }

        }

        // All of the below commented methods can be reused when search, login, etc functionality is implemented

        //private async void ProceduresButton_Clicked(object sender, EventArgs e)
        //{
        //    ProcedureGrid.IsVisible = true;
        //    // update activeButtonBox
        //    Rectangle rectangle = ProceduresButton.Bounds;
        //    rectangle.Width -= 4;
        //    rectangle.Height -= 4;
        //    rectangle.Y += 2;
        //    rectangle.X += 2;
        //    await activeButtonBox.LayoutTo(rectangle, 500, Easing.CubicInOut);
        //}


        private async void AboutUs_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage(mainViewModel));
        }

        //private async void Search_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CategoriesPage());
        //}


        //private async void ClinicalScenariosButton_Clicked(object sender, EventArgs e)
        //{
        //    ProcedureGrid.IsVisible = false;
        //    // update activeButtonBox
        //    Rectangle rectangle = ClinicalScenariosButton.Bounds;
        //    rectangle.Width -= 2;
        //    rectangle.Height -= 4;
        //    rectangle.Y += 2;
        //    await activeButtonBox.LayoutTo(rectangle, 500, Easing.CubicInOut);
        //}

        //private void Database_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
