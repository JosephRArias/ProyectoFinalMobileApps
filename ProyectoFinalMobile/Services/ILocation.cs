using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace ProyectoFinalMobile.Services
{
	public interface ILocation
	{
		Position ReturnDevicePosition();
	}
}
