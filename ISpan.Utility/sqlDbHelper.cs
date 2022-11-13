using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Utility
{
	public class sqlDbHelper
	{
		private string connstring;

		public sqlDbHelper(string KeyOfConnstring)
		{
			connstring = System.Configuration.ConfigurationManager
							   .ConnectionStrings[KeyOfConnstring].ConnectionString;
		}

		public void Executenonquery(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connstring))
			{
				var command = new SqlCommand(sql, conn);
				conn.Open();
				command.Parameters.AddRange(parameters);
				command.ExecuteNonQuery();
			}
		}

		public DataTable Select(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connstring))
			{
				var command=new SqlCommand(sql, conn);
				if (parameters != null)
				{
					command.Parameters.AddRange(parameters);
				}

				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet,"Db");
				return dataSet.Tables["Db"];
			}
		}
	}
} 
