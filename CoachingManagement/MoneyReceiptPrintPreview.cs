using System;
using System.Windows.Forms;

namespace CoachingManagement
{
    public partial class MoneyReceiptPrintPreview : Form
    {
        FeeReceiptPrintDAO feeReceiptPrintDAO = new FeeReceiptPrintDAO();
        StudentFeeDAO studentFeeDAO = new StudentFeeDAO();
        string feeid;
        public MoneyReceiptPrintPreview(string feeid)
        {
            this.feeid = feeid;
            InitializeComponent();
        }

        private void MoneyReceiptPrintPreview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coachingmanagementDataSet6.StudentFee' table. You can move, or remove it, as needed.
            this.StudentFeeTableAdapter.Fill(this.coachingmanagementDataSet6.StudentFee);

            this.FeeReceiptVeiwer.RefreshReport();
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            string stdroll = feeReceiptPrintDAO.GetStudentInfoForMoneyReceipt(feeid).Tables[0].Rows[0]["StudentId"].ToString();
            string stdname = feeReceiptPrintDAO.GetStudentName(stdroll).Tables[0].Rows[0]["StdName"].ToString();
            string stdclass = feeReceiptPrintDAO.GetStudentInfoForMoneyReceipt(feeid).Tables[0].Rows[0]["ClassName"].ToString();
            string stdbatch = feeReceiptPrintDAO.GetStudentInfoForMoneyReceipt(feeid).Tables[0].Rows[0]["BatchName"].ToString();
            string stdfee = feeReceiptPrintDAO.GetStudentInfoForMoneyReceipt(feeid).Tables[0].Rows[0]["MonthlyFee"].ToString();
            string feestatus = feeReceiptPrintDAO.GetStudentInfoForMoneyReceipt(feeid).Tables[0].Rows[0]["FeeStatus"].ToString();
           
            try
            {
                //rollno = "Ratul";
                ReportParameter[] allPar = new ReportParameter[6]; // create parameters array
                ReportParameter parroll = new ReportParameter("studentroll", stdroll);
                ReportParameter parname = new ReportParameter("studentname", stdname);
                ReportParameter parclass = new ReportParameter("class", stdclass);
                ReportParameter parbatch = new ReportParameter("batch", stdbatch);
                ReportParameter parfee = new ReportParameter("monthlyfee", stdfee);
                ReportParameter parstatus = new ReportParameter("feestatus", feestatus);
                allPar[0] = parroll;
                allPar[1] = parname;
                allPar[2] = parclass;
                allPar[3] = parbatch;
                allPar[4] = parfee;
                allPar[5] = parstatus;
                FeeReceiptVeiwer.LocalReport.SetParameters(allPar); // set parameter array
                this.FeeReceiptVeiwer.RefreshReport();


            }
            catch (Exception)
            {
                MessageBox.Show("Paro nai");
            }


        }
    }
}
