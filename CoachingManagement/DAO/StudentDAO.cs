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
    class StudentDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;

        public StudentDAO()
        {
            
        }

        public DataSet GetStudent()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StudentId as [Student Roll], StdName as [Student Name], ClassName as [Class Name], BatchName as [Batch Name], StdFee as [Monthly Fee], StdInsta as [Student's Institution],StdAddress as [Current Address], StdPhone as [Student Phone], GurPhone as [Gurdian Phone], YoA as [Year of Admission], SerialNo as [Application Form No.] from Student";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }


        public DataSet GetStudentClass(string stdroll)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName from Student where StudentId = '" + stdroll + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentSubject(string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubName from Subjects where ClassName = '" + classname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentSubjectCode(string subname,string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubCode from Subjects where ClassName = '" + classname + "' and SubName = '"+subname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
       

        public DataSet GetStudentClassWithId(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName from Student where StudentId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentBatchWithId(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select BatchName from Student where StudentId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentSerialWithId(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SerialNo from Student where StudentId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetStudentFeeWithId(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StdFee from Student where StudentId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
        public void AddStudent(StudentDTO studentDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into Student values('"+studentDTO.SERIALNO+"','" + studentDTO.STDNAME + "','" + studentDTO.STDINSTA + "','" + studentDTO.STDCLASS + "','" + studentDTO.CLSCODE + "','" + studentDTO.STDBATCH + "','" + studentDTO.STDADDRESS + "','" + studentDTO.STDPHONE + "','" + studentDTO.GURPHONE + "','" + studentDTO.STDFEE + "','" + studentDTO.STDYEAR + "')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show("added Successfully!!");

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Class Name or Class Code already exits. Try new name for class", "Error..");

                }
            }

        }

        public void UpdateStudent(string stdrollno, string stdname, string stdinsta, string stdclass, string stdbatch, string stdaddress, string stdphone, string gurphone, int serialno,string stdfee, int stdyear,string clscode)
        {
            connectionDB.OpenConnection();
            string sqlQuery2 = "update Student set StdName = '" + stdname + "', StdInsta = '" + stdinsta + "',ClassName = '" + stdclass + "', BatchName = '" + stdbatch + "', StdAddress = '" + stdaddress + "', StdPhone = '" + stdphone + "',GurPhone = '" + gurphone + "',StdFee = '" + stdfee + "', ClassCode = '"+clscode+"' where SerialNo = '" + serialno + "'";
            connectionDB.ExecuteQueries(sqlQuery2);
            connectionDB.CloseConnection();

        }

        public void DeleteStudent(int serial, string stdclass,string roll)
        {
            connectionDB.OpenConnection();
            string sqlQuery3 = "delete from StudentFee where StudentId='" + roll + "'";
            connectionDB.ExecuteQueries(sqlQuery3);
            connectionDB.CloseConnection();
            connectionDB.OpenConnection();
            string sqlQuery2 = "delete from StudentResult where StudentId='" + roll + "'";
            connectionDB.ExecuteQueries(sqlQuery2);
            connectionDB.CloseConnection();
            connectionDB.OpenConnection();
            string sqlQuery1 = "delete from Student where (SerialNo = '" + serial + "') and (ClassName = '" + stdclass + "')";
            connectionDB.ExecuteQueries(sqlQuery1);
            connectionDB.CloseConnection();

            

           
        }
    }
}
