using Prism.Commands;
using Prism.Navigation;
using ProyectoFinalMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalMobile.ViewModels
{
	public class RestaurantMasterDetailPageViewModel
	{
		INavigationService _navigationService;
		MenuOptions options;

		public MenuOptions SelectedOption
		{
			get { return options; }
			set
			{
				options = value;
				if (options != null)
				{
					Task selectOptionTask = OnSelectOptionAsync(options);
				}
			}
		}
		public ObservableCollection<MenuOptions> Options { get; set; }

		async Task OnSelectOptionAsync(MenuOptions options)
		{
			await _navigationService.NavigateAsync($"{options.Page}");
		}

		public RestaurantMasterDetailPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GetMenuOptions();
		}

		private void GetMenuOptions()
		{
			Options = new ObservableCollection<MenuOptions>()
			{
				new MenuOptions{Name = NavigationConstants.Explore.Name, Page=NavigationConstants.Explore.Route, IconSource=NavigationConstants.Explore.IconSource },
				new MenuOptions{Name = NavigationConstants.Profile.Name, Page = NavigationConstants.Profile.Route, IconSource=NavigationConstants.Profile.IconSource},
				new MenuOptions{Name = NavigationConstants.Favorites.Name, Page = NavigationConstants.Favorites.Route, IconSource=NavigationConstants.Favorites.IconSource}

			};
		}

		async void Navigate(string page)
		{
			await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
		}
	}
}
