using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using Excel;
namespace CoachingManagement
{
    class ResultDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        StudentDAO studentDAO = new StudentDAO();
        private DataSet dataSet;


        public ResultDAO()
        {
         
            
        }

        public void ImportResult(string excelfilepath)
        {


            //declare variables - edit these based on your particular situation
            string ssqltable = "StudentResult";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            string myexceldataquery = "select * from [sheet1$]";

            
        try
        {
            //create our connection strings
            string sexcelconnectionstring = @"provider=microsoft.ace.oledb.12.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 12.0;hdr=yes;\"";
            connectionDB.OpenConnection();
            //series of commands to bulk copy data from the excel file into our sql table
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionDB.GetConString());
            bulkcopy.DestinationTableName = ssqltable;

            while (dr.Read())
            {
                bulkcopy.WriteToServer(dr);
            }

            dr.Close();
            oledbconn.Close();
            connectionDB.CloseConnection();
            MessageBox.Show("File imported into sql server successfully.");
        }
        catch (SqlException ex)
        {
            if(ex.Number>0)
            {
                connectionDB.CloseConnection();
                MessageBox.Show("You may already add this info into database.");

            }
        }
           


        }

        public DataSet GetStudentResult()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select * from StudentResult";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetExamType(string roll)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select distinct ExamType from StudentResult where StudentId = '"+roll+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetMarkSheet(string roll, string exam)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select SubName, ObtainedMarks from StudentResult where StudentId = '"+roll+"' and ExamType = '"+exam+"' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetTotalExamMarks(string roll, string exam)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select sum(ExamMarks) as TotalMarks from StudentResult where StudentId = '" + roll + "' and ExamType = '" + exam + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetTotalObtainedMarks(string roll, string exam)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select sum(ObtainedMarks) as TotalMarks from StudentResult where StudentId = '" + roll + "' and ExamType = '" + exam + "' ";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

        public DataSet GetAllStudentRollOfClass(string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select StudentId from Student where ClassName ='"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }



        
        public void AddResult(ResultDTO resultDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into StudentResult values('"+resultDTO.STDID+"','"+resultDTO.CLASS+"','"+resultDTO.BATCH+"','"+resultDTO.SUBNAME+"','"+resultDTO.SUBCODE+"','"+resultDTO.EXAMTYPE+"','"+resultDTO.EXAMMARKS+"','"+resultDTO.OBTAINEDMARKS+"')";
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
                    MessageBox.Show("You may already add this info into database.", "Error..");

                }
            }

        }


        public void UpdateResult(string examid,string stdid,string classname,string batchname,string subname,string subcode,string examtype,string exammarks,string obtain)
        {
            connectionDB.OpenConnection();
            string sqlQuery2 = "update StudentResult set StudentId = '"+stdid+"',ClassName = '"+classname+"',BatchName = '"+batchname+"',SubName='"+subname+"',SubCode='"+subcode+"',ExamType='"+examtype+"',ExamMarks='"+exammarks+"',ObtainedMarks='"+obtain+"'";
            connectionDB.ExecuteQueries(sqlQuery2);
            connectionDB.CloseConnection();

        }

        public void DeleteResult()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "delete from StudentResult";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }

        public void DeleteAnyResult(string id)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "delete from StudentResult where ExamId = '"+id+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }
    }
}
