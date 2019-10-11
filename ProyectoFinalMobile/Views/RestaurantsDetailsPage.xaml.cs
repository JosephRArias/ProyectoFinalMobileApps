﻿using ProyectoFinalMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsDetailsPage : ContentPage
    {
        public RestaurantsDetailsPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantsDetailsPageViewModel();
        }
    }
}