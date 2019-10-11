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
	public class LoginPageViewModel : INotifyPropertyChanged
    {
        public UserModel U { get; set; }
        public ICommand SaveData { get; set; }
        public ICommand RegisterPage { get; private set; }
        public string r { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginPageViewModel()
		{
            U = new UserModel();

            SaveData = new Command(async () =>
            {
                if (!Validations.IsnotEmpty(U.Username))
                {
                    r = "El nombre de usuario esta vacio";
                }
                else if (!Validations.IsnotEmpty(U.Password))
                {
                    r = "Inserte contraseña para continuar.";
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new RestaurantMasterDetailPage());
                }
            });

            RegisterPage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new SignupPage());
            });

        }
    }
}