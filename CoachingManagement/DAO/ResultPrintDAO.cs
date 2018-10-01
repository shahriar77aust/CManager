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
    class ResultPrintDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;



        public ResultPrintDAO()
        {

        }

        public DataSet GetResult(string id,string exam)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubName,SubCode,ObtainedMarks from StudentResult where StudentId='"+id+"' and ExamType='"+exam+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentName(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from Student where StudentId = '" + id + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentClass(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from Student where StudentId = '" + id + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentBatch(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from Student where StudentId = '" + id + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
    }
}
