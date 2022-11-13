using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ISpan.Utility;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"INSERT INTO Users(Name,Account,Password,DateOfBirth,Height)
							VALUES(@Name,@Account,@Password,getdate(),@Height)";

			try
			{
				var dbHelpder = new sqlDbHelper("default");

				var parameters =new sqlParameterBuilder()
									.AddNvarchar("Name",50,"Anny")
									.AddNvarchar("Account",50,"Anny123")
									.AddNvarchar("Password", 50, "1111")
									.AddDatetime("DateOfBirthd",DateTime.Now)
									.AddInt("Height",60).Build();

				parameters = new sqlParameterBuilder()
									.AddNvarchar("Name", 50, "Bob")
									.AddNvarchar("Account", 50, "Bobbbb")
									.AddNvarchar("Password", 50, "3333")
									.AddDatetime("DateOfBirthd", DateTime.Now)
									.AddInt("Height", 80).Build();

				parameters = new sqlParameterBuilder()
									.AddNvarchar("Name", 50, "Kan")
									.AddNvarchar("Account", 50, "Kanak")
									.AddNvarchar("Password", 50, "5555")
									.AddDatetime("DateOfBirthd", DateTime.Now)
									.AddInt("Height", 90).Build();

				dbHelpder.Executenonquery(sql, parameters);
				
				Console.WriteLine("data has been added!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"failed,reason:{ex.Message}");
			}
		}
	}
}
