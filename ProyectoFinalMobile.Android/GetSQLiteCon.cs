using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProyectoFinalMobile.Services;
using SQLite.Net;

namespace ProyectoFinalMobile.Droid
{
	public class GetSQLiteCon : ISQLiteInterface
	{
		public GetSQLiteCon()
		{

		}
		public SQLite.Net.SQLiteConnection GetSQLiteConnection()
		{
			var fileName = "UserDatabase.db3";
			var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentPath, fileName);
			var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var connection = new SQLiteConnection(platform, path);
			return connection;
		}
	}
}