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
    class TeacherSalaryDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;


        public TeacherSalaryDAO()
        {
        }


        public DataSet GetTeacherSalaryRecord()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select TeacherId as [Teacher Id], Salary as Salary, SalaryMonth as [Salary Month],SalaryYear as Year, SalaryStatus as [Status], SalaryId as [Salary Record no.] from TeacherSalary";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetSalary(string id)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "select Salary from Teacher where TeacherId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            return dataSet;         
            
        }

        public DataSet GetTeacherSalaryWithId(string id)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "select TeacherId as [Teacher Id], Salary as Salary, SalaryMonth as [Salary Month],SalaryYear as Year, SalaryStatus as [Status], SalaryId as [Salary Record no.] from TeacherSalary where TeacherId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            return dataSet;

        }

        public void AddTeacherSalary(TeacherSalaryDTO teacherSalaryDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into TeacherSalary values('"+teacherSalaryDTO.TID+"','"+teacherSalaryDTO.TSALARY+"','"+teacherSalaryDTO.TMONTH+"','"+teacherSalaryDTO.TYEAR+"','"+teacherSalaryDTO.TSTATUS+"')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show(" added Successfully as a Teacher");

            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry.\n Salary already paid!!", "Error..");

                }
            }

        }

        public void UpdateTeacherSalaryRecord(string sid,string id, string salary, string month, string status)
        {


            try
            {
                connectionDB.OpenConnection();
                string sqlQuery = "update TeacherSalary set Salary = '"+salary+"', SalaryMonth='"+month+"',SalaryStatus='"+status+"' where TeacherId = '"+id+"'";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show("Info Updated Successfully!");
            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry.\nTeacher with same name or id already exits!!", "Error..");

                }
            }

        }


        public void DeleteTeacherSalaryRecord(string sid)
        {


            try
            {
                connectionDB.OpenConnection();
                string sqlQuery = "delete TeacherSalary where SalaryId = '"+sid+"'";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show("Info Updated Successfully!");
            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry", "Error..");

                }
            }

        }

    }
}
