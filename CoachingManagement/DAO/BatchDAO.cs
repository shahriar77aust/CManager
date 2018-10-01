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
    class BatchDAO
    {
        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;



        public BatchDAO()
        {

        }

       

        public DataSet GetClassBatch()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName as [Class Name], ClassCode as [Class Code], BatchName as [Batch Name], MaxBatchStd as [Number Of Seat], NumberOfStd [Number Of Student], AvailableSeat as [Seat Available] from Batch";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();

            return dataSet;
        }
        public DataSet GetBatchComboBoxItems(string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select distinct BatchName from Batch where ClassName = '"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();

            return dataSet;
        }

        public DataSet GetAvailableSeat(string batch, string classname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select AvailableSeat from Batch where BatchName='"+batch+"' and ClassName='"+classname+"'";
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = new DataSet();
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();

            return dataSet;
        }

        public void CreateBatch(BatchDTO batchDTO, ClassDTO classDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into Batch values('" + classDTO.CLASSNAME + "','" + classDTO.CLASSCODE + "','" + batchDTO.BATCH + "','" + batchDTO.BATCHSTD + "','0','" + batchDTO.BATCHSTD + "')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("You have already added batch " + batchDTO.BATCH + " under " + classDTO.CLASSNAME + ". Try a new one.", "Error..");

                }
            }
            
        }
        public void UpdateBatchStudentNumberAfterAdd(string classname,string batchname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "update Batch set NumberOfStd = isnull((select count(*) from Student where (ClassName like '" + classname + "') and (BatchName like '" + batchname + "') group by ClassName,BatchName),0), AvailableSeat=(select ((MaxBatchStd-1) - NumberOfStd) from Batch where ClassName like '" + classname + "' and BatchName like '" + batchname + "') where ClassName like '" + classname + "' and BatchName like '" + batchname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }

        public void UpdateBatchStudentNumberAfterDelete(string classname, string batchname)
        {
            connectionDB.OpenConnection();
            string sqlQuery = "update Batch set NumberOfStd = isnull((select count(*) from Student where (ClassName like '" + classname + "') and (BatchName like '" + batchname + "') group by ClassName,BatchName),0), AvailableSeat=(select ((MaxBatchStd) - (NumberOfStd-1)) from Batch where ClassName like '" + classname + "' and BatchName like '" + batchname + "') where ClassName like '" + classname + "' and BatchName like '" + batchname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }
        public void UpdateBatch(string classname,string batchname,string classcode,string tmpclass,string tmpbatch,string max, string num, string avil)
        {
            int available = Convert.ToInt32(max) - Convert.ToInt32(num);
                try
                {

                    connectionDB.OpenConnection();
                    string sqlQuery3 = "update Batch set MaxBatchStd = '" + max + "', AvailableSeat = '" + available + "'  where BatchName = '" + batchname + "' and ClassName = '" + classname + "'";
                    connectionDB.ExecuteQueries(sqlQuery3);
                    connectionDB.CloseConnection();

                    connectionDB.OpenConnection();
                    string sqlQuery2 = "update Student set BatchName = '" + batchname + "',ClassName = '" + classname + "' where BatchName = '" + tmpbatch + "' and ClassName = '" + tmpclass + "'";
                    connectionDB.ExecuteQueries(sqlQuery2);
                    connectionDB.CloseConnection();


                    // MessageBox.Show("You have already added batch " + batchname + " under " + classname + ". Try a new one.", "Error..");

                }
                catch (SqlException ex)
                {
                    if (ex.Number > 0)
                    {
                        connectionDB.CloseConnection();
                        MessageBox.Show("Updating batch name feature will be added soon! .", "Sorry..");
                    }
                }
            
            
            
            
        }
        
        public void DeleteBatch(string batchname,string classname)
        {

            DialogResult result = MessageBox.Show("All the records of Batch :" + batchname + "  of Class :"+classname+"  will be deleted.",
                                                 "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                connectionDB.OpenConnection();
                string sqlQuery1 = "delete from Student where BatchName = '" + batchname + "' and ClassName = '" + classname + "' ";
                connectionDB.ExecuteQueries(sqlQuery1);
                connectionDB.CloseConnection();

                connectionDB.OpenConnection();
                string sqlQuery2 = "delete from Batch where BatchName = '" + batchname + "' and ClassName = '" + classname + "' ";
                connectionDB.ExecuteQueries(sqlQuery2);
                connectionDB.CloseConnection();
            }
            else
            {
                //go home do nothing!
            }
            
        }
    }
}
