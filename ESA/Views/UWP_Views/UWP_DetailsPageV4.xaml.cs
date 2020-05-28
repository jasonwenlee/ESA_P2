using ESA.MarkupExtensions;
using ESA.Models;
using ESA.Models.Model;
using ESA.Models.VideoView;
using ESA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.Views.UWP_Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UWP_DetailsPageV4 : ContentPage
    {
        // DetailsViewModel
        DetailsViewModel procedureViewModel;

        public UWP_DetailsPageV4(Procedure proc)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            // View Models
            BindingContext = procedureViewModel = new DetailsViewModel(proc);

            // Content Row
            StepsView stepsView = new StepsView(procedureViewModel);
            contentRow.Children.Clear();
            contentRow.Children.Add(stepsView);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourceVideoSource source = new ResourceVideoSource();
            UriVideoSource uriSource = new UriVideoSource();
            uriSource.Uri = procedureViewModel.Procedure.VideoSource;
            videoPlayer.Source = uriSource;

            videoPlayer.Play();
            videoPlayer.Position = procedureViewModel.VideoPosition;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            procedureViewModel.VideoPosition = videoPlayer.Position;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            // Video Player
            videoPlayer.HeightRequest = this.Width * 0.25;
            if (this.Width < 1350)
            {
                scrollView.Margin = new Thickness(20, 5);
            } else
            {
                scrollView.Margin = new Thickness(350, 5);
            }
        }

        public async void PlayButtonAnimation(object sender)
        {
            // update activeButtonBox
            Rectangle rectangle = ((Button)sender).Bounds;
            rectangle.Width -= 2;
            rectangle.Height -= 4;
            rectangle.Y += 2;
            await activeButtonBox.LayoutTo(rectangle, 500, Easing.CubicInOut);
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        // Tabs
        private void KeyPointsBtn_Clicked(object sender, EventArgs e)
        {
            IList<View> content = contentRow.Children;
            if (!(content.First() == null || content.First() is KeyPointsView))
            {
                content.Clear();
                content.Add(new KeyPointsView(procedureViewModel));

                PlayButtonAnimation(sender);
            }
        }

        private void VariationsBtn_Clicked(object sender, EventArgs e)
        {
            IList<View> content = contentRow.Children;
            if (!(content.First() == null || content.First() is VariationsView))
            {
                content.Clear();
                content.Add(new VariationsView(procedureViewModel));

                PlayButtonAnimation(sender);
            }
        }

        private void ComplicationsBtn_Clicked(object sender, EventArgs e)
        {
            IList<View> content = contentRow.Children;
            if (!(content.First() == null || content.First() is ComplicationsView))
            {
                content.Clear();
                content.Add(new ComplicationsView(procedureViewModel));
                PlayButtonAnimation(sender);
            }
        }

        private void InfoBtn_Clicked(object sender, EventArgs e)
        {
            IList<View> content = contentRow.Children;
            if (!(content.First() == null || content.First() is InfoView))
            {
                content.Clear();
                content.Add(new InfoView(procedureViewModel));

                PlayButtonAnimation(sender);
            }
        }

        private void stepsBtn_Clicked(object sender, EventArgs e)
        {
            IList<View> content = contentRow.Children;
            if (!(content.First() == null || content.First() is StepsView))
            {
                content.Clear();
                content.Add(new StepsView(procedureViewModel));

                PlayButtonAnimation(sender);
            }
        }
    }
}