using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.Models
{
	public class UserModel
	{
		[PrimaryKey]
		public int IDCard { get; set; }
		public string Username { get; set; }
		[MaxLength(20)]
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
