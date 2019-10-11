using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile
{
	public class NavigationConstants
	{
		public static class Profile
		{
			public static string Name = "Profile";
			public static string Route = "NavigationPage/ProfilePage";
			public static string IconSource = "ic_assignment_ind.png";
		}
		public static class Favorites
		{
			public static string Name = "Favorites";
			public static string Route = "NavigationPage/FavoritesPage";
			public static string IconSource = "ic_star.png";
		}
		public static class Explore
		{
			public static string Name = "Explore";
			public static string Route = "NavigationPage/ExplorePage";
			public static string IconSource = "ic_map.png";
		}
		public static class MasterDetail
		{
			public static string Name = "Home Page";
			public static string Route = "/RestaurantMasterDetailPage/NavigationPage";
			public static string IconSource = "ic_star.png";
		}
		public static class Search
		{
			public static string Name = "Search";
			public static string Route = "NavigationPage/SearchPlacePage";
			public static string IconSource = "ic_assignment_ind.png";
		}
		public static class Login
		{
			public static string Name = "Login";
			public static string Route = "LoginPage";
		}

	}
}
