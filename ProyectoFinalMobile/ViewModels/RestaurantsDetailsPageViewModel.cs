using Api.Services;
using ProyectoFinalMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoFinalMobile.ViewModels
{
	public class RestaurantsDetailsPageViewModel
    {
        IApiServices apiServices = new ApiServices();
        public ICommand getNearBySearchCommand { get; set; }
        public string Rnc { get; set; }
        public RestaurantsDetailsPageViewModel()
		{
            getNearBySearchCommand = new Command(async () =>
            {
                await getNearBySearch();
            });

            getNearBySearchCommand.Execute(null);
        }


        async Task getNearBySearch()
        {
            try
            {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    var result = await apiServices.getNearBySearch("18.491955, -69.93689");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
            }
        }

    }
}