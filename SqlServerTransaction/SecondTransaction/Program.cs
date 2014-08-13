using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTransaction
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
                    //var result = Select(Table1, "1");

                    Update(Table1, "1", "name1-Modified");

                    //Insert(Table1, "1", "name1");

                    //Delete(Table1, "1");

                    Update(Table1, "2", "name2-Modified");

                    transaction.Commit();
                }
            }
        }

        private static DataTable Select(string table, string id)
        {
            var command = transaction.Connection.CreateCommand();

            command.CommandText = string.Format(@"SELECT * FROM {0} WHERE id = @p_id ", table);

            command.Parameters.Add(new SqlParameter("@p_id", id));

            command.Transaction = transaction;

            var datatable = new DataTable();

            var adapter = new SqlDataAdapter(command);

            adapter.Fill(datatable);

            return datatable;
        }

        private static void Insert(string table, string id, string name)
        {
            var command = transaction.Connection.CreateCommand();

            command.CommandText = string.Format(@"INSERT INTO {0}
                                                            ([id]
                                                            ,[name])
                                                    VALUES  (@p_id
                                                            ,@p_name)", table);

            command.Parameters.Add(new SqlParameter("@p_id", id));
            command.Parameters.Add(new SqlParameter("@p_name", name));

            command.Transaction = transaction;

            command.ExecuteNonQuery();
        }

        private static void Update(string table, string id, string name)
        {
            var command = transaction.Connection.CreateCommand();

            command.CommandText = string.Format(@"UPDATE {0} SET name = @p_name WHERE id = @p_id ", table);

            command.Parameters.Add(new SqlParameter("@p_name", name));
            command.Parameters.Add(new SqlParameter("@p_id", id));

            command.Transaction = transaction;

            command.ExecuteNonQuery();
        }

        private static void Delete(string table, string id)
        {
            var command = transaction.Connection.CreateCommand();

            command.CommandText = string.Format(@"DELETE FROM {0} WHERE id = @p_id ", table);

            command.Parameters.Add(new SqlParameter("@p_id", id));

            command.Transaction = transaction;

            command.ExecuteNonQuery();
        }
    }
}