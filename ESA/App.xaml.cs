﻿using ESA.Services;
using ESA.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address

        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://azureapi-roec.azurewebsites.net" : "https://azureapi-roec.azurewebsites.net";

        //    public static string AzureBackendUrl =
        //DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";

        public App()
        {
            InitializeComponent();
            // Register AzureDataStore to allow Android, iOS, and Windows platform to access
            DependencyService.Register<AzureDataStore>();
            // MainPage = new MainPage();
            MainPage = new NavigationPage(new SplashPage()); // REC: Using the SplashPage.cs as the initial page.
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
