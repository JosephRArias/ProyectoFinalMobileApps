using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.Models
{
	
		public class LocationModel
		{
			public double Lat { get; set; }
			public double Lng { get; set; }
		}
		public class Northeast
		{
			public double Lat { get; set; }
			public double Lng { get; set; }
		}

		public class Southwest
		{
			public double Lat { get; set; }
			public double Lng { get; set; }
		}

		public class Viewport
		{
			public Northeast Northeast { get; set; }
			public Southwest Southwest { get; set; }
		}

		public class Geometry
		{
			public LocationModel Location { get; set; }
			public Viewport Viewport { get; set; }
		}

		public class OpeningHours
		{
			public bool Open_now { get; set; }
		}

		public class Photo
		{
			public int Height { get; set; }
			public IList<string> Html_attributions { get; set; }
			public string Photo_reference { get; set; }
			public int Width { get; set; }
		}

		public class PlusCode
		{
			public string Compound_code { get; set; }
			public string Global_code { get; set; }
		}

		public class Result
		{
			public Geometry Geometry { get; set; }
			public string Icon { get; set; }
			public string Id { get; set; }
			public string Name { get; set; }
			public OpeningHours Opening_hours { get; set; }
			public IList<Photo> Photos { get; set; }
			public string Place_id { get; set; }
			public PlusCode Plus_code { get; set; }
			public double Rating { get; set; }
			public string Reference { get; set; }
			public string Scope { get; set; }
			public IList<string> Types { get; set; }
			public int User_ratings_total { get; set; }
			public string Vicinity { get; set; }
		}

		public class Restaurants
		{
			public IList<object> Html_attributions { get; set; }
			public IList<Result> Results { get; set; }
			public string Status { get; set; }
		}
	}
