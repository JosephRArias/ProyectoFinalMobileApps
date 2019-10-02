using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.ViewModels
{
	public class RestaurantMasterDetailPageViewModel
	{
		INavigationService _navigationService;
		public DelegateCommand<string> OnExploreCommand { get; set; }
		public DelegateCommand<string> OnProfileCommand { get; set; }
		public DelegateCommand<string> OnFavoritesCommand { get; set; }
		public RestaurantMasterDetailPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			OnExploreCommand = new DelegateCommand<string>(Navigate);
			OnProfileCommand = new DelegateCommand<string>(Navigate);
			OnFavoritesCommand = new DelegateCommand<string>(Navigate);
		}
		
		async void Navigate(string page)
		{
			await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
		}
	}
}
