using Prism.Navigation;
using Prism.Services;
using ProyectoFinalMobile.Helpers;
using ProyectoFinalMobile.Models;
using ProyectoFinalMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalMobile.ViewModels
{
	public class SignupPageViewModel
	{
			public UserModel RData { get; set; }
			public ICommand SaveRegister { get; set; }
			public string Result { get; set; }
		public SignupPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
		{
			RData = new UserModel();

			SaveRegister = new Command(async () =>
			{
				if (!Validations.IsnotEmpty(RData.Username))
				{
					Result = "El nombre de usuario esta vacio";
				}
				else if (!Validations.IsnotEmpty(RData.Password) || !Validations.IsnotEmpty(RData.ConfirmPassword))
				{
					Result = "Las contraseña es requerida ";
				}
				else if (!Validations.IsEqual(RData.Password, RData.ConfirmPassword))
				{
					Result = "Las contraseñas no coinciden";
				}
				else
				{
					await navigationService.NavigateAsync(new Uri(NavigationConstants.MasterDetail.Route, UriKind.Absolute));
				}
			});
		}
	}
}
