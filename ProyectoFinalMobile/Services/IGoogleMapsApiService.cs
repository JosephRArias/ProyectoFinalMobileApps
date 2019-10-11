using ProyectoFinalMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMobile.Services
{
	public interface IGoogleMapsApiService
	{
		Task<GoogleDirection> GetDirections(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude);
	}
}
