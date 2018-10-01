using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CoachingManagement
{
    class StudentFeeDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;

        public StudentFeeDAO()
        {

        }


        public DataSet GetStudentFeeRecord()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StudentId as [Student Roll], ClassName as [Class Name], BatchName as [Batch Name],MonthlyFee as [Monthly Fee], FeeMonth as [Fee Of Month], FeeYear as [Year], FeeStatus as [Status], FeeId as [Payment Id] from StudentFee";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetPendingFee(string classname)
        {
            string status = "pending";
            connectionDB.OpenConnection();
            string sqlQuery = "select StudentId as [Student Roll], ClassName as [Class Name], BatchName as [Batch Name],MonthlyFee as [Monthly Fee], FeeMonth as [Fee Of Month], FeeYear as [Year], FeeStatus as [Status], FeeId as [Payment Id] from StudentFee where FeeStatus='"+status+"' and ClassName='"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public void AddStudentFee(StudentFeeDTO studentFeeDTO)
        {

            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into StudentFee values('"+studentFeeDTO.STDID+"','"+studentFeeDTO.CLASS+"','"+studentFeeDTO.BATCH+"','"+studentFeeDTO.MONTHLYFEE+"','"+studentFeeDTO.FEEMONTH+"','"+studentFeeDTO.FEEYEAR+"','"+studentFeeDTO.FEESTATUS+"')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                //MessageBox.Show(teacherDTO.TNAME + " added Successfully as a Teacher");

            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry.\n You already paid for this month", "Error..");

                }
            }

        }

        public void DeleteFee(int fid)
        {


            connectionDB.OpenConnection();
            string sqlQuery = "delete StudentFee  where FeeId = '" + fid + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Delete Successful!");

        }

        public void UpdateFee(int feeid, string stdid, string classname, string batchname, string monthlyfee, string feemonth, string feeyear, string feestatus)
        {


            connectionDB.OpenConnection();
            string sqlQuery = "update StudentFee set StudentId='"+stdid+"',ClassName='"+classname+"',BatchName='"+batchname+"',MonthlyFee='"+monthlyfee+"',FeeMonth='"+feemonth+"',FeeYear='"+feeyear+"',FeeStatus='"+feestatus+"'  where FeeId = '" + feeid + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Update Successful!");

        }
    }
}
