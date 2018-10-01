using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoachingManagement
{
    class ConnectionDB
    {
        public String conString = "Data Source=DESKTOP-4KQ5H3K;Initial Catalog=coachingmanagements;Integrated Security=True";
        public SqlConnection sqlConnection;
        public SqlCommand sqlCommand;
        public SqlDataAdapter sqlAdapter;
        public DataSet dataSet;

        public string GetConString()
        {
            return conString;
        }

        public void OpenConnection()
        {
            sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
        }


        public void ExecuteQueries(string Query)
        {
            sqlCommand = new SqlCommand(Query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            
        } 


        public DataSet DataAdapter()
        {
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            sqlAdapter.SelectCommand = sqlCommand;
            dataSet = new DataSet();
            sqlAdapter.Fill(dataSet);
            return dataSet;
        }

        public void CloseConnection()
        {
            sqlConnection.Close();
        }

    }
}
