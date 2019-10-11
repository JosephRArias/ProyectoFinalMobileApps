using Prism.Navigation;
using Prism.Services;
using ProyectoFinalMobile.Helpers;
using ProyectoFinalMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalMobile.ViewModels
{
	public class LoginPageViewModel : INotifyPropertyChanged
	{
		public UserModel U { get; set; }
		public ICommand SaveData { get; set; }
		public ICommand RegisterPage { get; private set; }
		public event PropertyChangedEventHandler PropertyChanged;
		public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
		{
			U = new UserModel();

			SaveData = new Command(async () =>
			{
				if (!Validations.IsnotEmpty(U.Username))
				{
					await pageDialogService.DisplayAlertAsync("Error", "Username is empty", "Retry");
				}
				else if (!Validations.IsnotEmpty(U.Password))
				{
					await pageDialogService.DisplayAlertAsync("Error", "Password is empty", "Retry");
				}
				else
				{
					await navigationService.NavigateAsync(new Uri(NavigationConstants.MasterDetail.Route, UriKind.Absolute));
				}
			});

			RegisterPage = new Command(async () =>
			{
				await navigationService.NavigateAsync(new Uri("SignupPage", UriKind.Relative));
			});

		}
	}
}
