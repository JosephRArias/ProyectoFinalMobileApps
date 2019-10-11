using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalMobile.Services
{
	public interface ISQLiteInterface
	{
		SQLiteConnection GetSQLiteConnection();
	}
}
