using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using ProyectoFinalMobile.ViewModels;
using ProyectoFinalMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinalMobile
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer)
		{

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<RestaurantMasterDetailPage, RestaurantMasterDetailPageViewModel>();
			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<ExplorePage>();
			containerRegistry.RegisterForNavigation<FavoritesPage>();
			containerRegistry.RegisterForNavigation<ProfilePage>();
		}

		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync($"{Config.MasterDetail}/NavigationPage");
		}
	}
}
