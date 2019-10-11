using Prism.Navigation;
using Prism.Services;
using ProyectoFinalMobile.Helpers;
using ProyectoFinalMobile.Models;
using ProyectoFinalMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoFinalMobile.ViewModels
{
	public class SignupPageViewModel
	{
        public UserModel RData { get; set; }
        public ICommand SaveRegister { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public SignupPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
		{
            RData = new UserModel();

            SaveRegister = new Command(async () =>
            {
                if (!Validations.IsnotEmpty(RData.Username))
                {
                    await pageDialogService.DisplayAlertAsync("Error", "Something is missing", "Retry");
                }
                else if (!Validations.IsnotEmpty(RData.Email))
                {
                    await pageDialogService.DisplayAlertAsync("Error", "Something is missing", "Retry");
                }
                else if (!Validations.IsnotEmpty(RData.Password) || !Validations.IsnotEmpty(RData.ConfirmPassword))
                {
                    await pageDialogService.DisplayAlertAsync("Error", "Something is missing", "Retry");
                }
                else if (!Validations.IsEqual(RData.Password, RData.ConfirmPassword))
                {
                    await pageDialogService.DisplayAlertAsync("Error", "Passwords don't match", "Retry");
                }
                else
                {
                    await navigationService.NavigateAsync(new Uri("/RestaurantMasterDetailPage", UriKind.Absolute));
                }
            });
        }

    }
}

		

