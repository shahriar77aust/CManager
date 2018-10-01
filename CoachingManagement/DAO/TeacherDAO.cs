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
    class TeacherDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;


        public TeacherDAO()
        {
            
        }

        public DataSet GetTeacher()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select TeacherId as [Teacher Id], TeacherName as [Teacher Name], ClassName as [Class Name], BatchName as [Batch Name], SubName as [Subject Name],SubCode as [Subject Code],phoneno as [Phone Number],TeacherEmail as [Teacher Email],CurrentAddress as [Current Address],Salary as [Teacher Salary] from Teacher";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetTeacherWithId(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select TeacherId as [Teacher Id], TeacherName as [Teacher Name], ClassName as [Class Name], BatchName as [Batch Name], SubName as [Subject Name],SubCode as [Subject Code],phoneno as [Phone Number],TeacherEmail as [Teacher Email],CurrentAddress as [Current Address],Salary as [Teacher Salary] from Teacher where TeacherId like '%"+id+"%'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }


        public DataSet GetNumberOfTeacher()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select count (distinct TeacherId) as NumberOfTeacher from Teacher";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
        

        public void AddTeacher(TeacherDTO teacherDTO)
        {

            
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into Teacher values('" + teacherDTO.ID + "','" + teacherDTO.TNAME + "',isnull('" + teacherDTO.CLASS + "',0),isnull('" + teacherDTO.TBATCH + "',0),isnull('" + teacherDTO.SUBNAME + "',0),isnull('" + teacherDTO.SUBCODE + "',0),'" + teacherDTO.PHONE + "','" + teacherDTO.TEMAIL + "','" + teacherDTO.ADDRESS + "','" + teacherDTO.TSALARY + "')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show(teacherDTO.TNAME + " added Successfully as a Teacher");

            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry.\nTeacher with id already exits!!", "Error..");

                }
            }

        }

        public void UpdateTeacher(int tserial,string tname,string tclass,string tbatch,string tsub,string tsubcode,string temail,string tphone,string taddress,string tsalary)
        {


            try
            {
                connectionDB.OpenConnection();
                string sqlQuery = "update Teacher set TeacherName = '" + tname + "', SubName = '" + tsub + "',BatchName = '" + tbatch + "',ClassName = '" + tclass + "',SubCode = '" + tsubcode + "', phoneno = '" + tphone + "',TeacherEmail = '" + temail + "', CurrentAddress = '" + taddress + "', Salary = '" + tsalary + "'  where TeacherId = '" + tserial + "'";
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
                    MessageBox.Show("Sorry.\nTeacher with id already exits!!", "Error..");

                }
            }

        }

        public void DeleteTeacher(int id,string tname)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "delete Teacher  where TeacherId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Deleted SuccessfullY!");

            connectionDB.OpenConnection();
            string sqlQuery2 = "delete TeacherSalary  where TeacherId = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery2);
            connectionDB.CloseConnection();
            
        }

        public void DeleteClassOfTeacher(int tid,string classname)
        {


            connectionDB.OpenConnection();
            string sqlQuery = "delete Teacher  where TeacherId = '"+tid+"' and ClassName = '"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Delete Successful!\n This Teacher is no more assigned to "+classname);

        }

        public void DeleteBatchOfTeacher(int tid,string classname, string batchname)
        {


            connectionDB.OpenConnection();
            string sqlQuery = "delete Teacher  where TeacherId = '"+tid+"' and ClassName = '" + classname + "' and BatchName = '" + batchname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Delete Successful!\n This Teacher is no more assigned to Batch " + batchname + " of " + classname);

        }

        public void DeleteSubjectOfTeacher(int tid,string subcode,string subname,string classname)
        {


            connectionDB.OpenConnection();
            string sqlQuery = "delete Teacher  where TeacherId = '"+tid+"' and SubCode = '"+subcode+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
            MessageBox.Show("Delete Successful!\n This Teacher is no more assigned to Subject: " + subname +" of Class:"+classname);

        }
    }
}