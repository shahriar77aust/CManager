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
    class FeeReceiptPrintDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;

        public FeeReceiptPrintDAO()
        {

        }

        public DataSet GetStudentInfoForMoneyReceipt(string fid)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from StudentFee where FeeId = '" + fid + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
        public DataSet GetStudentName(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StdName from Student where StudentId = '" + id + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
    }
}
