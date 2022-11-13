using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace select
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"SELECT Id,Name,Account,Password,DateOfBirth,Height FROM Users WHERE Id>=@Id";

			try
			{
				var DbHelper = new sqlDbHelper("default");
				var parameters = new sqlParameterBuilder().AddInt("Id", 3).Build();
				DataTable user = DbHelper.Select(sql,parameters);

				foreach (DataRow row in user.Rows)
				{
					int Id = row.Field<int>("Id");
					string Name= row.Field<string>("Name");
					string Account = row.Field<string>("Account");
					string Password = row.Field<string>("Password");
					DateTime DateOfBirth = row.Field<DateTime>("DateOfBirth");
					int Height = row.Field<int>("Height");

					Console.WriteLine($"Id={Id},Name={Name},Account={Account},DateOfBirth={DateOfBirth},Height={Height}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"failed,reason:{ex.Message}");
			}
		}
	}
}
