using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProyectoFinalMobile.Services;
using Xamarin.Forms.GoogleMaps;

namespace ProyectoFinalMobile.Droid
{
	public class Location : ILocation
	{
		public Position ReturnDevicePosition()
		{
			Position myPosition = new Position();
			try
			{
				Accuracy DesiredAccuracy = Accuracy.Fine;
				var locationManager = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
				if (locationManager.AllProviders.Count > 0)
				{
					var criteria = new Criteria
					{
						Accuracy = DesiredAccuracy
					};

					var provider = locationManager.GetBestProvider(criteria, true);

					myPosition = new Position(locationManager.GetLastKnownLocation(provider).Latitude, locationManager.GetLastKnownLocation(provider).Longitude);
				}
				return myPosition;
			}
			catch
			{
				return myPosition;
			}
		}
	}
}