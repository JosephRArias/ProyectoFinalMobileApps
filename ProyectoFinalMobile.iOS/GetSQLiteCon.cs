using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using ProyectoFinalMobile.Services;
using UIKit;

namespace ProyectoFinalMobile.iOS
{
	public class GetSQLiteCon : ISQLiteInterface
	{
		public SQLite.Net.SQLiteConnection GetSQLiteConnection()
		{
			var fileName = "Student.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, fileName);
			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var connection = new SQLite.Net.SQLiteConnection(platform, path);
			return connection;
		}
	}
}