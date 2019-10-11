using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.Models
{
	public class PlaceModel
	{
		public IList<CandidateModel> Candidates { get; set; }
		public string Status { get; set; }
	}
}
