using Prism.Navigation;
using ProyectoFinalMobile.Models;
using ProyectoFinalMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace ProyectoFinalMobile.ViewModels
{
	public class ExplorePageViewModel
	{
		INavigationService _navigationService;
		public ICommand CalculateRouteCommand { get; set; }
		public ICommand UpdatePositionCommand { get; set; }

		IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
		public ExplorePageViewModel()
		{
			GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
			GetPlaceDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
			GetLocationNameCommand = new Command<Position>(async (param) => await GetLocationName(param));

		}
		GooglePlaceAutoCompletePrediction _placeSelected;
		public GooglePlaceAutoCompletePrediction PlaceSelected
		{
			get
			{
				return _placeSelected;
			}
			set
			{
				_placeSelected = value;
				if (_placeSelected != null)
					GetPlaceDetailCommand.Execute(_placeSelected);
			}
		}
		public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
		public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

		public ICommand GetLocationNameCommand { get; set; }
		public bool ShowRecentPlaces { get; set; }
		public ICommand GetPlacesCommand { get; set; }
		public ICommand GetPlaceDetailCommand { get; set; }
		string _destinationLatitud;
		string _destinationLongitud;

		public async Task GetPlacesByName(string placeText)
		{
			var places = await googleMapsApi.GetPlaces(placeText);
			var placeResult = places.AutoCompletePlaces;
			if (placeResult != null && placeResult.Count > 0)
			{
				Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
			}

			ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
		}

		public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
		{
			var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
			if (place != null)
			{
					_destinationLatitud = $"{place.Latitude}";
					_destinationLongitud = $"{place.Longitude}";

					RecentPlaces.Add(placeA);


			}
		}



		//Get place 
		public async Task GetLocationName(Position position)
		{
			try
			{
				var placemarks = await Geocoding.GetPlacemarksAsync(position.Latitude, position.Longitude);
				var placemark = placemarks?.FirstOrDefault();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

	}
	}
