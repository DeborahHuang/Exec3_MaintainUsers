using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace update
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE Users SET Name=@Name,Account=@Account
							,Password=@Password,DateOfBirth=getdate()
							,Height=@Height WHERE Id=@Id";

			var DbHelper = new sqlDbHelper("default");
			try
			{
				var parameters=new sqlParameterBuilder().AddNvarchar("Name",50,"xavierModified")
														.AddNvarchar("Account",50, "xavier330Modified")
														.AddNvarchar("Password",50, "11223344Modified")
														.AddDatetime("DateOfBirth",DateTime.Now)
														.AddInt("Height",45)
														.AddInt("Id",4)
														.Build();
				DbHelper.Executenonquery(sql, parameters);

				Console.WriteLine("data has been updated!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"failed,reason:{ex.Message}");
			}

		}
	}
}
