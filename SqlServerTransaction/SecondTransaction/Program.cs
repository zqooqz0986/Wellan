using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTransaction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var connection = new SqlConnection("server=JOSEPH-LU;uid=sa;pwd=xj6u04vmp;database=IB00SS;"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    var command = transaction.Connection.CreateCommand();

                    command.CommandText = @"UPDATE [dbo].[LutestTable] SET [name] = '10' WHERE [id] = '1'";
                    command.Transaction = transaction;

                    var scalar = command.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }
    }
}