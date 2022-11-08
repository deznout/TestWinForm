using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace TestAssignment
{
    internal class MyDB
    {
        static string connectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TestAssignmentDB; Integrated Security = True; Pooling = False";

        SqlConnection sqlConnection = new SqlConnection(connectstring);

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

    }
}
