using Newtonsoft.Json;
using ProyectoFinalMobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMobile.Services
{
	public class GoogleMapsApiService : IGoogleMapsApiService
	{
		static string _googleMapsKey;

		public static void Initialize(string ApiKey)
		{
			_googleMapsKey = ApiKey;
		}

		public async Task<GoogleDirection> GetDirections(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude)
		{
			GoogleDirection googleDirection = new GoogleDirection();

			using (var httpClient = CreateClient())
			{
				var response = await httpClient.GetAsync($"api/directions/json?mode=driving&transit_routing_preference=less_driving&origin={originLatitude},{originLongitude}&destination={destinationLatitude},{destinationLongitude}&key={_googleMapsKey}").ConfigureAwait(false);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					if (!string.IsNullOrWhiteSpace(json))
					{
						googleDirection = await Task.Run(() =>
						   JsonConvert.DeserializeObject<GoogleDirection>(json)
						).ConfigureAwait(false);

					}
				}
			}

			return googleDirection;
		}


		private const string ApiBaseAddress = "https://maps.googleapis.com/maps/";
		private HttpClient CreateClient()
		{
			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(ApiBaseAddress)
			};

			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return httpClient;
		}
	}
}
