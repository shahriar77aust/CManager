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
    class SubjectDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;


        public SubjectDAO()
        {

        }

        public DataSet GetSubject()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubName as [Subject Name], SubCode as [Subject Code], ClassName as [Class Name], ClassCode as [Class Code], id as [Row Id] from Subjects";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }



        public DataSet GetSubjectCode(string subname,string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubCode from Subjects where SubName = '" + subname + "' and ClassName = '"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetSubjectName(string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from Subjects where ClassName = '"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

       

        

        public void AddSubject(SubjectDTO subjectDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into Subjects values('" + subjectDTO.CLASSNAME + "','" + subjectDTO.CLASSCODE + "','" + subjectDTO.SUBNAME + "','" + subjectDTO .SUBCODE+ "')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show(" added Successfully!!");

            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Class Name or Class Code already exits. Try new one!", "Error..");

                }
            }

        }

        public void UpdateSubject(string classname,string classcode, string subname, string subcode, int id)
        {
            try
            {
                connectionDB.OpenConnection();
                string sqlQuery = "update Subjects set ClassName = '" + classname + "', ClassCode = '" + classcode + "',SubName = '" + subname + "',SubCode = '" + subcode + "' where id = '" + id + "'";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();


                connectionDB.OpenConnection();
                string sqlQuery2 = "update Teacher set SubName = '" + subname + "' where SubCode = '" + subcode + "'";
                connectionDB.ExecuteQueries(sqlQuery2);
                connectionDB.CloseConnection();

            }
            catch (SqlException ex)
            {
                if (ex.Number > 0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Sorry. Something went worng.\n Check the Subject Code Number.", "Error..");

                }
            }
            
        }

        public void DeleteSubject(int id,string subname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "delete Subjects  where id = '" + id + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();

            connectionDB.OpenConnection();
            string sqlQuery2 = "delete Teacher where SubName = '" + subname + "'";
            connectionDB.ExecuteQueries(sqlQuery2);
            connectionDB.CloseConnection();
        }


    }
}
