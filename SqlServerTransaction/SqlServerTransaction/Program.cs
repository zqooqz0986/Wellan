using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTransaction
{
    internal class Program
    {
        private readonly static string Table1 = "dbo.LutestTable";

        private readonly static string Table2 = "dbo.LutestSecondTable";

        private readonly static string ConnectionString = "server=JOSEPH-LU;uid=sa;pwd=xj6u04vmp;database=IB00SS;";

        private static SqlTransaction transaction = null;

        private static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    //var result = Select(Table1);

                    //var result = Select(Table1, "1");

                    var result = SelectName(Table1, "name1");

                    //var result = Count(Table1, "3");

                    transaction.Commit();
                }
            }
        }

        private static DataTable Select(string table, string id = null)
        {
            var command = transaction.Connection.CreateCommand();

            if (string.IsNullOrEmpty(id))
            {
                command.CommandText = string.Format(@"SELECT * FROM {0}", table);
            }
            else
            {
                command.CommandText = string.Format(@"SELECT * FROM {0} WHERE id = @p_id ", table);
                command.Parameters.Add(new SqlParameter("@p_id", id));
            }

            command.Transaction = transaction;

            var datatable = new DataTable();

            var adapter = new SqlDataAdapter(command);

            adapter.Fill(datatable);

            return datatable;
        }

        private static DataTable SelectName(string table, string name = null)
        {
            var command = transaction.Connection.CreateCommand();

            if (string.IsNullOrEmpty(name))
            {
                command.CommandText = string.Format(@"SELECT * FROM {0}", table);
            }
            else
            {
                command.CommandText = string.Format(@"SELECT * FROM {0} WHERE name = @p_name ", table);
                command.Parameters.Add(new SqlParameter("@p_name", name));
            }

            command.Transaction = transaction;

            var datatable = new DataTable();

            var adapter = new SqlDataAdapter(command);

            adapter.Fill(datatable);

            return datatable;
        }

        private static int Count(string table, string id = null)
        {
            var command = transaction.Connection.CreateCommand();

            if (string.IsNullOrEmpty(id))
            {
                command.CommandText = string.Format(@"SELECT Count(*) FROM {0}", table);
            }
            else
            {
                command.CommandText = string.Format(@"SELECT Count(*) FROM {0} WHERE id = @p_id ", table);
                command.Parameters.Add(new SqlParameter("@p_id", id));
            }

            command.Transaction = transaction;

            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
}