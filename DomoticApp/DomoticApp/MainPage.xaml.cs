﻿using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DomoticApp.Views.Popups;
using System.Net.Http;
using Rg.Plugins.Popup.Services;
using DomoticApp.Views.Dormitorio;
using DomoticApp.Views.Sala;

namespace DomoticApp
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    { 
        private const string urlApagarLed1 = "http://10.0.0.17/L";
        private readonly HttpClient client = new HttpClient();
        private string content;
        LoadingNetworkPage loadingRed = new LoadingNetworkPage();
        CorrectNetworkPage redCorrecta = new CorrectNetworkPage();
        IncorrectNetworkPage redIncorrecta = new IncorrectNetworkPage();

        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            if (CrossConnectivity.Current.IsConnected)
                RedCorrecta();
            else
                RedIncorrecta();
        }
        [Obsolete]
        async void RedCorrecta()
        {
            content = await client.GetStringAsync(urlApagarLed1);
            await PopupNavigation.PushAsync(loadingRed);
            await Task.Delay(2500);
            string acceso, clave;
            acceso = content.Substring(0, 9);
            clave = content.Substring(9, 8);

            if (acceso == "TEJADANET" && clave == "NT190875")
            {
                await PopupNavigation.RemovePageAsync(loadingRed);
                await PopupNavigation.PushAsync(redCorrecta);
                await Task.Delay(2000);
            }
        }
        [Obsolete]
        async void RedIncorrecta()
        {
            await PopupNavigation.RemovePageAsync(loadingRed);
            await PopupNavigation.PushAsync(redIncorrecta);
            await Task.Delay(2000);
        }
        [Obsolete]
        async void ValidameOtraVez()
        {

        }

        private void btnDormitorio_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new ControlDormitorioPage()));
        }

        private void btnCocina_Clicked(object sender, EventArgs e)
        {
            

        }

        private void btnAreaLavado_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnSala_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new ControlSalaPage()));
        }

        private void btnBano_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRecibidor_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPiscina_Clicked(object sender, EventArgs e)
        {

        }

        private void btnTinaco_Clicked(object sender, EventArgs e)
        {

        }

        private void btnExteriores_Clicked(object sender, EventArgs e)
        {

        }
    }
}