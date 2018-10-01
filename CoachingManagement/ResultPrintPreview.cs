using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CoachingManagement
{
    public partial class ResultPrintPreview : Form
    {
        ResultPrintDAO resultPrintDAO = new ResultPrintDAO();
        ResultDAO resultDAO = new ResultDAO();
        public string roll, exam;
        public ResultPrintPreview(string roll, string exam)
        {

            InitializeComponent();
            this.roll = roll;
            this.exam = exam;
        }

        private void ResultPrintPreview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coachingmanagementDataSet4.Student' table. You can move, or remove it, as needed.
            this.StudentTableAdapter.Fill(this.coachingmanagementDataSet4.Student);
            // TODO: This line of code loads data into the 'coachingmanagementDataSet.StudentResult' table. You can move, or remove it, as needed.
            this.StudentResultTableAdapter.Fill(this.coachingmanagementDataSet.StudentResult);
            this.reportViewer1.RefreshReport();
            LoadStudentInfo();
            LoadResult();
            
        }

        private void LoadResult()
        {
            try
            {
               //stde = resultPrintDAO.GetResult(roll).Tables[0];
                StudentResultBindingSource.DataSource = resultPrintDAO.GetResult(roll,exam).Tables[0];

            }catch(Exception)
            {
                MessageBox.Show("Paro nai");
            }
        }

        private void LoadStudentInfo()
        {
            //string stdroll = resultPrintDAO.GetStudentName(roll).Tables[0].Rows[0]["StdName"].ToString()
            string stdname = resultPrintDAO.GetStudentName(roll).Tables[0].Rows[0]["StdName"].ToString();
            string stdclass = resultPrintDAO.GetStudentClass(roll).Tables[0].Rows[0]["ClassName"].ToString();
            string stdbatch = resultPrintDAO.GetStudentBatch(roll).Tables[0].Rows[0]["BatchName"].ToString();
            string stdobtainmarks = Convert.ToString(resultDAO.GetTotalObtainedMarks(roll, exam).Tables[0].Rows[0]["TotalMarks"]);
            try
            {
                //rollno = "Ratul";
                ReportParameter[] allPar = new ReportParameter[6]; // create parameters array
                ReportParameter parroll = new ReportParameter("stdroll", roll);
                ReportParameter parname = new ReportParameter("stdname", stdname);
                ReportParameter parclass = new ReportParameter("stdclass", stdclass);
                ReportParameter parbatch = new ReportParameter("stdbatch", stdbatch);
                ReportParameter parexam = new ReportParameter("examname", exam);
                ReportParameter parobtainmarks = new ReportParameter("stdobtainmarks", stdobtainmarks);
                allPar[0] = parroll;
                allPar[1] = parname;
                allPar[2] = parclass;
                allPar[3] = parbatch;
                allPar[4] = parexam;
                allPar[5] = parobtainmarks;
                reportViewer1.LocalReport.SetParameters(allPar); // set parameter array
                this.reportViewer1.RefreshReport();


            }
            catch(Exception)
            {
                MessageBox.Show("Paro nai");
            }
           
            
        }

    }
}
