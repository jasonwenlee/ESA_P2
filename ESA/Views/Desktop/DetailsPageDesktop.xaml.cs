using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ESA.Models.VideoView;
using ESA.ViewModels;
using ESA.Models.Model;

namespace ESA.Views.Desktop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPageDesktop : ContentPage
    {
        // Don't remove :)
        //Procedure holdProcedure;

        // ProcedureViewModel
        DetailsViewModel procedureViewModel;

        public DetailsPageDesktop(Procedure proc)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            // View Models
            BindingContext = procedureViewModel = new DetailsViewModel(proc);

            // View Bindings
            stepsView.procedureViewModel = procedureViewModel;
            keyPointsView.procedureViewModel = procedureViewModel;
            variationsView.procedureViewModel = procedureViewModel;
            complicationsView.procedureViewModel = procedureViewModel;
            infoView.procedureViewModel = procedureViewModel;

            // Don't remove :)
            //holdProcedure = proc;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResourceVideoSource source = new ResourceVideoSource();
            UriVideoSource uriSource = new UriVideoSource();
            uriSource.Uri = procedureViewModel.Procedure.VideoSource;

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        uriSource.Uri = procedureViewModel.Procedure.VideoSource;
            //        //source.Path = "Videos/Brain_Eyes_Vid.mp4";                    
            //        break;
            //    case Device.Android:
            //        uriSource.Uri = procedureViewModel.Procedure.VideoSource;
            //        //source.Path = "Brain_Eyes_Vid.mp4";
            //        break;
            //    case Device.UWP:
            //        uriSource.Uri = procedureViewModel.Procedure.VideoSource;
            //        //source.Path = "Videos/Brain_Eyes_Vid.mp4";
            //        break;
            //}

            videoPlayer.Source = uriSource;
            videoPlayer.Play();
            videoPlayer.Position = procedureViewModel.VideoPosition;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            procedureViewModel.VideoPosition = videoPlayer.Position;
            videoPlayer.Stop();
        }

    }
}