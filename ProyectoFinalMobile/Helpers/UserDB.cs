using ProyectoFinalMobile.Models;
using ProyectoFinalMobile.Services;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ProyectoFinalMobile.Helpers
{
		public class UserDB
		{
			private SQLiteConnection _SQLiteConnection;
			public UserDB()
			{
				_SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
				_SQLiteConnection.CreateTable<UserModel>();
			}
			public IEnumerable<UserModel> GetUsers()
			{
				return (from u in _SQLiteConnection.Table<UserModel>()
						select u).ToList();
			}
			public UserModel GetSpecificUser(int id)
			{
				return _SQLiteConnection.Table<UserModel>().FirstOrDefault(t => t.IDCard == id);
			}
			public void DeleteUser(int id)
			{
				_SQLiteConnection.Delete<UserModel>(id);
			}
			public string AddUser(UserModel user)
			{
				var data = _SQLiteConnection.Table<UserModel>();
				var d1 = data.Where(x => x.IDCard == user.IDCard).FirstOrDefault();
				if (d1 == null)
				{
					_SQLiteConnection.Insert(user);
					return "Sucessfully Added";
				}
				else
					return "Already Mail id Exist";
			}
			public bool updateUserValidation(string userid)
			{
				var data = _SQLiteConnection.Table<UserModel>();
				var d1 = (from values in data
						  where values.Username == userid
						  select values).Single();
				if (d1 != null)
				{
					return true;
				}
				else
					return false;
			}
			public bool updateUser(string username, string pwd)
			{
				var data = _SQLiteConnection.Table<UserModel>();
				var d1 = (from values in data
						  where values.Username == username
						  select values).Single();
				if (true)
				{
					d1.Password = pwd;
					_SQLiteConnection.Update(d1);
					return true;
				}
				else
					return false;
			}
			public bool LoginValidate(string userName1, string pwd1)
			{
				var data = _SQLiteConnection.Table<UserModel>();
				var d1 = data.Where(x => x.Username == userName1 && x.Password == pwd1).FirstOrDefault();
				if (d1 != null)
				{
					return true;
				}
				else
					return false;
			}
		}
	}