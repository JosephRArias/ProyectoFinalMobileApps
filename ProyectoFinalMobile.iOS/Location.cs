using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using ProyectoFinalMobile.Services;
using UIKit;
using Xamarin.Forms.GoogleMaps;

namespace ProyectoFinalMobile.iOS
{
	public class Location : ILocation
	{
		public Position ReturnDevicePosition()
		{
			Position myPosition = new Position();
			try
			{
				if (CLLocationManager.LocationServicesEnabled)
				{
					CLLocationManager locationManager = new CLLocationManager();
					locationManager.RequestWhenInUseAuthorization();
					var location = locationManager.Location;
					myPosition = new Position(location.Coordinate.Latitude, location.Coordinate.Longitude);
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