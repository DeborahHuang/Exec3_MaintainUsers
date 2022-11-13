using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "DELETE FROM Users WHERE Id=@Id";
			var DbHelper = new sqlDbHelper("default");
			try
			{
				var parameters=new sqlParameterBuilder()
									.AddInt("Id",2)
									.Build();
				DbHelper.Executenonquery(sql, parameters);

				Console.WriteLine("Data Has been deleted!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"failed,reason:{ex.Message}");
			}
		}
	}
}
