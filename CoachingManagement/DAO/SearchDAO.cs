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
    class SearchDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;


        public SearchDAO()
        {
            
        }

        public DataSet GetClassWithName(string name)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName as [Class Name], ClassCode as [Class Code], MonthlyFee as [Monthly Fee], NumberOfStd as [Number of Admitted Student], AvailableSeat as [Available Seat],TotalSeat as [Total Seat]  from Class where ClassName like '%" + name + "%'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentWithId(string sid)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StudentId as [Student Roll], StdName as [Student Name], ClassName as [Class Name], BatchName as [Batch Name], StdFee as [Monthly Fee], StdInsta as [Student's Institution],StdAddress as [Current Address], StdPhone as [Student Phone], GurPhone as [Gurdian Phone], YoA as [Year of Admission], SerialNo as [Application Form No.] from Student where StudentId like '%" + sid + "%'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
    }
}
