using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerTransaction
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

                    command.CommandText = @"SELECT Count(*) FROM LutestTable";
                    command.Transaction = transaction;

                    var scalar = command.ExecuteScalar();
                    transaction.Commit();
                }
            }
        }
    }
}