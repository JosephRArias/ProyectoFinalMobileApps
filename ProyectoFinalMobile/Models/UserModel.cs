using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.Models
{
	public class UserModel
	{
		
		public int IDCard { get; set; }
       public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
