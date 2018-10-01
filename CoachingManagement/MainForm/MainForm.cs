using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office;
using System.Runtime.InteropServices;
using Excel1 = Microsoft.Office.Interop.Excel;

namespace CoachingManagement
{
    public partial class MainForm : Form
    {
        string tmpcode, tmpclass, totalseat, numberofstd, availableseat, tmpclassbatch, tmpbatch, tmpmaxbatchstd,numberofbatchstd, availablebatchseat, tmpstdclass, tmpstdbatch, teachersubcombovalue;
        
        ClassDAO classDAO = new ClassDAO();
        BatchDAO batchDAO = new BatchDAO();
        StudentDAO studentDAO = new StudentDAO();
        SubjectDAO subjectDAO = new SubjectDAO();
        TeacherDAO teacherDAO = new TeacherDAO();
        ResultDAO resultDAO = new ResultDAO();
        TeacherSalaryDAO teacherSalaryDAO = new TeacherSalaryDAO();
        StudentFeeDAO studentFeeDAO = new StudentFeeDAO();
        SearchDAO searchDAO = new SearchDAO();

        //ResultPrintDAO resultPrintDAO = new ResultPrintDAO();
        //ResultPrintPreview resultPrintPreview = new ResultPrintPreview();
        
        
        public MainForm()
        {
            InitializeComponent();
            timer1.Start();

            LoadSearchCatagory();//load search category name in category combo box in search page
            LoadClassComboBox(); //load 'class name' in the combo box where needed
            LoadClassBatch(); //load 'batch' data in grid view
            LoadClass(); //load 'class' data in grid view
            LoadStudent(); //load Student data in grid view
            LoadSubject(); //load Subject data in grid view
            LoadNumberOfTeacher();
            LoadTeacher();  //load Teacher data in grid view
            LoadTeacherSalaryRecord();//load teacher salary grid view data
            LoadSalaryStatus();//teacher salary status combo box item load in salary page
            LoadSalaryMonth();//load teacher salary month in salary page
            LoadStudentResult();//
            LoadStudentFee();
        }

       


        private void MainForm_Load(object sender, EventArgs e)
        {
            day.Text = System.DateTime.Now.DayOfWeek.ToString();//will show current day of the week
        }


        //timer for current date and time
        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("T");
            date.Text = DateTime.Now.ToString("D");
            tsalaryyearbox.Text = DateTime.Now.Year.ToString();
            feeyearbox.Text = DateTime.Now.Year.ToString();
        }


        //!!---------------------- ALL COMBO BOX LOAD STARTS-------------------------------------!!//


        // load items(Class Name) in Combo Box from Class Table
        private void LoadClassComboBox()
        {
            //in class tab
            classcombo.DisplayMember = "ClassName";
            classcombo.ValueMember = "Class";
            classcombo.DataSource = classDAO.GetClassComboBoxItems().Tables[0];

            //in student tab
            studentclasscombo.DisplayMember = "ClassName";
            studentclasscombo.ValueMember = "Class";
            studentclasscombo.DataSource = classDAO.GetClassComboBoxItems().Tables[0];

            //in sub tab
            subclasscombo.DisplayMember = "ClassName";
            subclasscombo.ValueMember = "Class";
            subclasscombo.DataSource = classDAO.GetClassComboBoxItems().Tables[0];

            //in teacher sub selection
            teacherclasscombo.DisplayMember = "ClassName";
            teacherclasscombo.ValueMember = "Class";
            teacherclasscombo.DataSource = classDAO.GetClassComboBoxItems().Tables[0];

        }

        // load items(Batch Name) in Combo Box from Batch Table
        private void LoadBatchComboBox(string classname)
        {
            //in student tab
            studentbatchcombo.DisplayMember = "BatchName";
            studentbatchcombo.ValueMember = "Batch";
            studentbatchcombo.DataSource = batchDAO.GetBatchComboBoxItems(classname).Tables[0];
            //in teacher sub selection
            tbatchcombo.DisplayMember = "BatchName";
            tbatchcombo.ValueMember = "Batch";
            tbatchcombo.DataSource = batchDAO.GetBatchComboBoxItems(classname).Tables[0];

        }


        private void LoadSubjectName(string classname)
        {
            teachersubcombo.DisplayMember = "SubName";
            teachersubcombo.ValueMember = "Sub";
            teachersubcombo.DataSource = subjectDAO.GetSubjectName(classname).Tables[0];
        }

        private void LoadMonthlyFee(string classname)
        {
            studentfeebox.DisplayMember = "MonthlyFee";
            studentfeebox.ValueMember = "Fee";
            studentfeebox.DataSource = classDAO.GetClassFee(classname).Tables[0];

        }

        private void LoadExamTypeComboBoxItem(string roll)
        {
            stdexamtypecombo.DisplayMember = "ExamType";
            stdexamtypecombo.ValueMember = "ExamType";
            stdexamtypecombo.DataSource = resultDAO.GetExamType(roll).Tables[0];
        }

        // combo box in batch tab,
        private void classcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classcombo.SelectedIndex > -1)
            {
                String classname = classcombo.Text;
                LoadClassCode(classname);
            }
        }


        //combo box in student tab
        private void studentclasscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentbatchcombo.Text = "--select batch--";
            studentfeebox.Text = "--monthly fee--";

            if (classcombo.SelectedIndex > -1)
            {

                String classname = studentclasscombo.Text;
                LoadBatchComboBox(classname);
                LoadMonthlyFee(classname);
                LoadClassCode(classname);
            }
        }



        //!!---------------------- ALL COMBO BOX LOAD ENDS-------------------------------------!!//




        //------------------- search tab starts ---------------------------//
        private void LoadSearchCatagory()
        {
            searchcatacombo.Items.Add("Class");
            searchcatacombo.Items.Add("Batch");
            searchcatacombo.Items.Add("Student");

        }

        private void searchquerybox_TextChanged(object sender, EventArgs e)
        {

            if (searchcatacombo.Text == "Class")
            {
                string query = searchquerybox.Text;
                searchdataview.DataSource = searchDAO.GetClassWithName(query).Tables[0];

                searchresult.Text = "Class Details";

            }
            else if (searchcatacombo.Text == "Student")
            {
                string query = searchquerybox.Text;
                searchdataview.DataSource = searchDAO.GetStudentWithId(query).Tables[0];

                searchresult.Text = "Student Details";

            }

        }

        private void searchcatacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchcatacombo.SelectedItem.ToString() == "Class")
            {
                labelsearchquery.Text = "Enter Class Name";

            }
            else if (searchcatacombo.SelectedItem.ToString() == "Batch")
            {
                labelsearchquery.Text = "Enter Batch Name";
            }
            else if (searchcatacombo.SelectedItem.ToString() == "Student")
            {
                labelsearchquery.Text = "Enter Student Roll";
            }
        }

        //!!-------------------- search tab ends   --------------------------!!//



        // -------------------------- class tab stars ----------------------------//

        //load data in grid view from Class Table
        private void LoadClass()
        {
            dataviewclass.DataSource = classDAO.GetClass().Tables[0];
        }

        //class create
        private void classcreatebtn_Click(object sender, EventArgs e)
        {
            if (classbox.Text == "" || classcodebox.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string classname = classbox.Text;
                string classcode = classcodebox.Text;
                string classfee = classfeebox.Text;
                classDAO.CreateClass(new ClassDTO(classname, classcode, classfee));
                LoadClassComboBox();
                LoadClass();
            }

        }

        private void classupdatebtn_Click(object sender, EventArgs e)
        {
            if (classbox.Text == "" || classcodebox.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string classname = classbox.Text;
                string classcode = classcodebox.Text;
                string classfee = classfeebox.Text;
                string rowid = idbox.Text;
                MessageBox.Show("tmpcode" + tmpcode + "\n tmpclass" + tmpclass + "\n totalseat" + totalseat + "\n numberofstd" + numberofstd + "\n availableseat" + availableseat);
                classDAO.UpdateClass(classname, classcode, classfee, tmpcode, tmpclass, totalseat, numberofstd, availableseat, rowid);
                LoadClassBatch();
                LoadClassComboBox();
                LoadClass();
                LoadStudent();
            }
        }

        //class delete
        private void classdelbtn_Click(object sender, EventArgs e)
        {
            if (classbox.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string classname = classbox.Text;
                string classcode = classcodebox.Text;
                string classfee = classfeebox.Text;
                classDAO.DeleteClass(classname);
                classbox.Text = "";
                classcodebox.Text = "";
                classcombo.Text = "";
                studentnamebox.Text = "";
                studentinstabox.Text = "";
                studentclasscombo.Text = "";
                // classcode.Text = "";
                studentbatchcombo.Text = "";
                studentaddressbox.Text = "";
                studentphonebox.Text = "";
                gurdianphonebox.Text = "";
                studentfeebox.Text = "";
                LoadClassBatch();
                LoadClass();
                LoadStudent();
                LoadSubject();
                LoadTeacher();
                LoadStudentResult();
                LoadStudentFee();
                LoadTeacherSalaryRecord();
            }

            LoadClassComboBox();
        }


        //data of class table
        private void dataviewclass_SelectionChanged(object sender, EventArgs e)
        {
            if (dataviewclass.SelectedRows.Count == 1)
            {
                int idx = dataviewclass.SelectedRows[0].Index;
                classbox.Text = dataviewclass.Rows[idx].Cells[0].Value.ToString();
                classcodebox.Text = dataviewclass.Rows[idx].Cells[1].Value.ToString();
                classfeebox.Text = dataviewclass.Rows[idx].Cells[2].Value.ToString();
                tmpcode = classcodebox.Text;
                tmpclass = classbox.Text;
                totalseat = dataviewclass.Rows[idx].Cells[4].Value.ToString();
                numberofstd = dataviewclass.Rows[idx].Cells[3].Value.ToString();
                availableseat = dataviewclass.Rows[idx].Cells[5].Value.ToString();
                idbox.Text = dataviewclass.Rows[idx].Cells[6].Value.ToString();
            }
        }


        //!!----------------------------- class tab ends ------------------------!!//



        //----------------- batch tab starts ------------------------------//

        //load data in grid view from Batch Table
        private void LoadClassBatch()
        {

            dataview.DataSource = batchDAO.GetClassBatch().Tables[0];

        }

        private void dataview_SelectionChanged(object sender, EventArgs e)
        {
            if (dataview.SelectedRows.Count == 1)
            {
                int idx = dataview.SelectedRows[0].Index;
                classcombo.Text = dataview.Rows[idx].Cells[0].Value.ToString();
                codebox.Text = dataview.Rows[idx].Cells[1].Value.ToString();
                batchbox.Text = dataview.Rows[idx].Cells[2].Value.ToString();
                maxstd.Text = dataview.Rows[idx].Cells[3].Value.ToString();
                tmpbatch = batchbox.Text;
                tmpclassbatch = classcombo.Text;
                tmpmaxbatchstd = dataview.Rows[idx].Cells[3].Value.ToString();
                numberofbatchstd = dataview.Rows[idx].Cells[4].Value.ToString();
                availablebatchseat = dataview.Rows[idx].Cells[5].Value.ToString();

            }
        }


        //batch create under class

        private void batchcreatebtn_Click_1(object sender, EventArgs e)
        {
            if (batchbox.Text == "" || classcombo.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string batchname = batchbox.Text;
                string classname = classcombo.Text;
                string classcode = codebox.Text;
                string classfee = classfeebox.Text;
                int maxbatchstd = Convert.ToInt32(maxstd.Text);
                batchDAO.CreateBatch(new BatchDTO(batchname, maxbatchstd), new ClassDTO(classname, classcode, classfee));
                LoadClassBatch();
                classDAO.UpdateClassAfterAddStudent(classname);
                LoadClass();
            }
        }

        private void batchupdatebtn_Click_1(object sender, EventArgs e)
        {
            if (batchbox.Text == "" || classcombo.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string batchname = batchbox.Text;
                string classname = classcombo.Text;
                string classcode = codebox.Text;
                string maxbatchstd = maxstd.Text;
                MessageBox.Show("tmpClass: " + tmpclassbatch + " tmpBatch: " + tmpbatch + " maxstd:" + maxbatchstd + " numofstd:" + numberofbatchstd + "avail: " + availablebatchseat);

                if (Convert.ToInt32(maxbatchstd) >= Convert.ToInt32(numberofbatchstd))
                {
                    batchDAO.UpdateBatch(classname, batchname, classcode, tmpclassbatch, tmpbatch, maxbatchstd, numberofbatchstd, availablebatchseat);
                    LoadClassBatch();
                    LoadStudent();
                    classDAO.UpdateClassAfterAddStudent(classname);
                    classDAO.UpdateClassAfterDelStudent(classname);
                    LoadClass();
                }
                else
                {
                    MessageBox.Show("Sorry!\n You can not update seat number which is less than number of student of the batch.");
                }
                
            }

        }

        private void batchdelbtn_Click_1(object sender, EventArgs e)
        {
            if (batchbox.Text == "")
            {
                MessageBox.Show("Information Is Empty.", "Error..");
            }
            else
            {
                string batchname = batchbox.Text;
                string classname = classcombo.Text;
                batchDAO.DeleteBatch(batchname, classname);
                batchbox.Text = "";
                classcombo.Text = "";
                studentnamebox.Text = "";
                studentinstabox.Text = "";
                studentclasscombo.Text = "";
                classcode.Text = "";
                studentbatchcombo.Text = "";
                studentaddressbox.Text = "";
                studentphonebox.Text = "";
                gurdianphonebox.Text = "";
                studentfeebox.Text = "";

                LoadClassBatch();
                LoadStudent();
                classDAO.UpdateClassAfterAddStudent(classname);
                LoadClass();
            }
        }


        // !!------------------------ batch tab ends -------------------------------!! //




        private Boolean CheckSeatAvailability(string batch, string classname)
        {
            string value = batchDAO.GetAvailableSeat(batch, classname).Tables[0].Rows[0]["AvailableSeat"].ToString();
            MessageBox.Show(value);
            if (Convert.ToInt32(value) > 0)
            {
                return true;
            }
            return false;
        }



        //---------------------------- STUDENT tab starts --------------------------//
        private void LoadStudent()
        {
            studentview.DataSource = studentDAO.GetStudent().Tables[0];
        }

        private void stdquicksearch_TextChanged(object sender, EventArgs e)
        {
            string query = stdquicksearch.Text;
            studentview.DataSource = searchDAO.GetStudentWithId(query).Tables[0];

        }
        private void studentaddbtn_Click(object sender, EventArgs e)
        {
            if(serialbox.Text != "" && studentnamebox.Text != "" && studentinstabox.Text != "" && studentclasscombo.Text != "" && studentbatchcombo.Text!="" && studentaddressbox.Text != "" && studentphonebox.Text != "" && gurdianphonebox.Text != "")
            {
                string serial = (serialbox.Text);
                int serialno = Convert.ToInt32(serial);
                string stdname = studentnamebox.Text;
                string stdinsta = studentinstabox.Text;
                string stdclass = studentclasscombo.Text;
                string clscode = classcode.Text;
                string stdbatch = studentbatchcombo.Text;
                string stdaddress = studentaddressbox.Text;
                string stdphone = studentphonebox.Text;
                string gurphone = gurdianphonebox.Text;
                string stdfee = studentfeebox.Text;
                int stdyear = Convert.ToInt32(yoabox.Text);

                if (CheckSeatAvailability(stdbatch, stdclass))
                {
                    studentDAO.AddStudent(new StudentDTO(serialno, stdname, stdinsta, stdclass, clscode, stdbatch, stdaddress, stdphone, gurphone, stdfee, stdyear));
                    LoadStudent();
                    batchDAO.UpdateBatchStudentNumberAfterAdd(stdclass, stdbatch);
                    LoadClassBatch();
                    classDAO.UpdateClassAfterAddStudent(stdclass);
                    LoadClass();
                }
                else
                {
                    DialogResult result = MessageBox.Show("You have already added Max. number of Student in this batch " + stdbatch + " of " + stdclass + ".\n If you want to add this student in this batch please update 'Maximum Number of Student' column in Batch section.",
                                                      "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {

                        tab.SelectedTab = batchpage;
                        MessageBox.Show("Update Maximum Number of Student of batch " + stdbatch + " of " + stdclass + ".");

                    }
                    else if (result == DialogResult.No)
                    {
                        //no...
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry!/nPlease provide all the information ask here.","Error..");
            }
            

        }

        private void studentview_SelectionChanged(object sender, EventArgs e)
        {

            if (studentview.SelectedRows.Count == 1)
            {
                int idx = studentview.SelectedRows[0].Index;
                serialbox.Text = studentview.Rows[idx].Cells[10].Value.ToString();
                 stdroll.Text = studentview.Rows[idx].Cells[0].Value.ToString();
                studentnamebox.Text = studentview.Rows[idx].Cells[1].Value.ToString();
                studentinstabox.Text = studentview.Rows[idx].Cells[5].Value.ToString();
                studentclasscombo.Text = studentview.Rows[idx].Cells[2].Value.ToString();
                //classcode = classcode.Text;
                studentbatchcombo.Text = studentview.Rows[idx].Cells[3].Value.ToString();
                studentaddressbox.Text = studentview.Rows[idx].Cells[6].Value.ToString();
                studentphonebox.Text = studentview.Rows[idx].Cells[7].Value.ToString();
                gurdianphonebox.Text = studentview.Rows[idx].Cells[8].Value.ToString();
                studentfeebox.Text = studentview.Rows[idx].Cells[4].Value.ToString();
                yoabox.Text = studentview.Rows[idx].Cells[9].Value.ToString();

                tmpstdclass = studentclasscombo.Text;
                tmpstdbatch = studentbatchcombo.Text;
            }
        }

        private void studentupdatebtn_Click(object sender, EventArgs e)
        {
          if(serialbox.Text != "" && studentnamebox.Text != "" && studentinstabox.Text != "" && studentclasscombo.Text != "" && studentbatchcombo.Text!="" && studentaddressbox.Text != "" && studentphonebox.Text != "" && gurdianphonebox.Text != "")
          {
              int serialno = Convert.ToInt32(serialbox.Text);
              string stdrollno = stdroll.Text;
              string stdname = studentnamebox.Text;
              string stdinsta = studentinstabox.Text;
              string stdclass = studentclasscombo.Text;
              string clscode = classcode.Text;
              string stdbatch = studentbatchcombo.Text;
              string stdaddress = studentaddressbox.Text;
              string stdphone = studentphonebox.Text;
              string gurphone = gurdianphonebox.Text;
              string stdfee = studentfeebox.Text;
              int stdyear = Convert.ToInt32(yoabox.Text);

              if (tmpstdclass == stdclass && tmpstdbatch == stdbatch)
              {
                  studentDAO.UpdateStudent(stdrollno, stdname, stdinsta, stdclass, stdbatch, stdaddress, stdphone, gurphone, serialno, stdfee, stdyear, clscode);
                  LoadStudent();
                  LoadStudentResult();
                  LoadStudentFee();

                  LoadClassBatch();

                  LoadClassBatch();
                  LoadStudent();

                  LoadClass();

                  LoadClass();
                  MessageBox.Show("Updated Successfully!");
              }
              else
              {
                  studentDAO.UpdateStudent(stdrollno, stdname, stdinsta, stdclass, stdbatch, stdaddress, stdphone, gurphone, serialno, stdfee, stdyear, clscode);
                  LoadStudent();

                  batchDAO.UpdateBatchStudentNumberAfterAdd(stdclass, stdbatch);
                  LoadClassBatch();
                  batchDAO.UpdateBatchStudentNumberAfterDelete(tmpstdclass, tmpstdbatch);
                  LoadClassBatch();
                  LoadStudent();
                  classDAO.UpdateClassAfterDelStudent(tmpstdclass);
                  LoadClass();
                  classDAO.UpdateClassAfterAddStudent(stdclass);
                  LoadClass();
                  MessageBox.Show("Updated Successfully!");
              }
          }
          else
          {
              MessageBox.Show("Sorry! Please select a student first from student list for update information","Error..");
          }
            
            

        }

        private void studentdelbtn_Click(object sender, EventArgs e)
        {
          if(serialbox.Text != "" && studentnamebox.Text != "" && studentinstabox.Text != "" && studentclasscombo.Text != "" && studentbatchcombo.Text!="" && studentaddressbox.Text != "" && studentphonebox.Text != "" && gurdianphonebox.Text != "")
          {
              int serialno = Convert.ToInt32(serialbox.Text);
              string stdrollno = stdroll.Text;
              string stdname = studentnamebox.Text;
              string stdinsta = studentinstabox.Text;
              string stdclass = studentclasscombo.Text;
              string clscode = classcode.Text;
              string stdbatch = studentbatchcombo.Text;
              string stdaddress = studentaddressbox.Text;
              string stdphone = studentphonebox.Text;
              string gurphone = gurdianphonebox.Text;
              string stdfee = studentfeebox.Text;
              int stdyear = Convert.ToInt32(yoabox.Text);

              DialogResult result = MessageBox.Show("Delete This Student?",
                                                    "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
              if (result == DialogResult.Yes)
              {
                  studentDAO.DeleteStudent(serialno, stdclass, stdrollno);
                  LoadStudent();
                  LoadStudentResult();
                  LoadStudentFee();
                  batchDAO.UpdateBatchStudentNumberAfterDelete(stdclass, stdbatch);
                  LoadClassBatch();
                  classDAO.UpdateClassAfterDelStudent(stdclass);
                  LoadClass();

              }
              else if (result == DialogResult.No)
              {
                  //no...
              }
          }else
          {
              MessageBox.Show("Sorry! Please select a student first from student list for delete", "Error..");

          }
            
           
        }

        private void subdataview_SelectionChanged(object sender, EventArgs e)
        {
            if (subdataview.SelectedRows.Count == 1)
            {
                int idx = subdataview.SelectedRows[0].Index;
                snamebox.Text = subdataview.Rows[idx].Cells[0].Value.ToString();
                scodebox.Text = subdataview.Rows[idx].Cells[1].Value.ToString();
                subclasscombo.Text = subdataview.Rows[idx].Cells[2].Value.ToString();
                subcodecombo.Text = subdataview.Rows[idx].Cells[3].Value.ToString();
                subidbox.Text = subdataview.Rows[idx].Cells[4].Value.ToString();
            }

        }

        //!!------------------------- STUDENT tab ends ------------------------- !!//


        //---------------------------- SUBJECT tab starts -----------------------//
        private void LoadSubject()
        {
            subdataview.DataSource = subjectDAO.GetSubject().Tables[0];
        }

        private void subaddbtn_Click(object sender, EventArgs e)
        {
            string sname = snamebox.Text;
            string scode = scodebox.Text;
            string subclass = subclasscombo.Text;
            string subcode = subcodecombo.Text;

            subjectDAO.AddSubject(new SubjectDTO(subclass, subcode, sname, scode));
            LoadSubject();
        }

        private void subupdatebtn_Click(object sender, EventArgs e)
        {
            string sname = snamebox.Text;
            string scode = scodebox.Text;
            string subclass = subclasscombo.Text;
            string subcode = subcodecombo.Text;
            int id = Convert.ToInt32(subidbox.Text);
            subjectDAO.UpdateSubject(subclass, subcode, sname, scode, id);
            LoadSubject();
            LoadTeacher();
        }

        private void subdelbtn_Click(object sender, EventArgs e)
        {
            string sname = snamebox.Text;
            string scode = scodebox.Text;
            string subclass = subclasscombo.Text;
            string subcode = subcodecombo.Text;
            int id = Convert.ToInt32(subidbox.Text);
            subjectDAO.DeleteSubject(id, sname);
            LoadSubject();
            LoadTeacher();
        }
        //!! -------------------------  SUBJECT tab ends ----------------------- !!//




        // ------------------------------ TEACHER tab starts -------------------  //
        private void LoadTeacher()
        {
            tdataview.DataSource = teacherDAO.GetTeacher().Tables[0];
        }
        private void LoadTeacherWithId(string id)
        {
            tdataview.DataSource = teacherDAO.GetTeacherWithId(id).Tables[0];
        }
        private void LoadNumberOfTeacher()
        {
            numberofteacher.Text = teacherDAO.GetNumberOfTeacher().Tables[0].Rows[0]["NumberOfTeacher"].ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
              string tid = textBox2.Text;
              LoadTeacherWithId(tid);
            }catch(Exception)
            {

            }
        }
        private void taddbtn_Click(object sender, EventArgs e)
        {
            string tserial =tserialbox.Text;
            if (tserial == "")
            {
                MessageBox.Show("Sorry!\n You cannot add a teacher without giving registration form number.");
                LoadTeacher();
            }
            else
            {
                int teacherSerial = Convert.ToInt32(tserial);
                string tname = tnamebox.Text;
                string temail = temailbox.Text;
                string tphone = tphonebox.Text;
                string taddress = taddressbox.Text;
                string tclass = teacherclasscombo.Text;
                string tbatch = tbatchcombo.Text;
                string tsub = teachersubcombo.Text;
                string tsubcode = tsubcodebox.Text;
                string tsalary = tsalarybox.Text;

                if (tclass == "" || tbatch == "")
                {
                    MessageBox.Show("Sorry!\n You cannot add a teacher without assigning any class or batch.");
                    LoadTeacher();
                }
                else if (tsub == "" || tsubcode == "")
                {
                    MessageBox.Show("Sorry!\n You cannot add a teacher without assigning any subject.");
                    LoadTeacher();

                }
                else
                {
                    teacherDAO.AddTeacher(new TeacherDTO(teacherSerial, tname, tclass, tbatch, tsub, tsubcode, temail, tphone, taddress, tsalary));
                    LoadTeacher();
                    LoadNumberOfTeacher();
                }
            }
            
            
        }

        private void tupdatebtn_Click(object sender, EventArgs e)
        {
            int tserial = Convert.ToInt32(tserialbox.Text);
            string tname = tnamebox.Text;
            string temail = temailbox.Text;
            string tphone = tphonebox.Text;
            string taddress = taddressbox.Text;
            string tclass = teacherclasscombo.Text;
            string tbatch = tbatchcombo.Text;
            string tsub = teachersubcombo.Text;
            string tsubcode = tsubcodebox.Text;
            string tsalary = tsalarybox.Text;
            teacherDAO.UpdateTeacher(tserial, tname, tclass, tbatch, tsub, tsubcode, temail, tphone, taddress, tsalary);
            LoadTeacher();
        }

        private void tdelbtn_Click(object sender, EventArgs e)
        {
            int tserial = Convert.ToInt32(tserialbox.Text);
            string tname = tnamebox.Text;
            string temail = temailbox.Text;
            string tphone = tphonebox.Text;
            string taddress = taddressbox.Text;
            string tclass = teacherclasscombo.Text;
            string tbatch = tbatchcombo.Text;
            string tsub = teachersubcombo.Text;
            string tsubcode = tsubcodebox.Text;

            DialogResult result = MessageBox.Show("Do you want to remove  all the records of " + tname + "( Teacher Id: " + tserial + ")?",
                                               "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                teacherDAO.DeleteTeacher(tserial, tname);
                LoadTeacher();
                LoadNumberOfTeacher();
                LoadTeacherSalaryRecord();
            }
            
        }

        private void delclassofteacher_Click(object sender, EventArgs e)
        {
            int tserial = Convert.ToInt32(tserialbox.Text);
            string tname = tnamebox.Text;
            string temail = temailbox.Text;
            string tphone = tphonebox.Text;
            string taddress = taddressbox.Text;
            string tclass = teacherclasscombo.Text;
            string tbatch = tbatchcombo.Text;
            string tsub = teachersubcombo.Text;
            string tsubcode = tsubcodebox.Text;
            DialogResult result = MessageBox.Show("Do you want to remove  Class: "+ tclass + " from " + tname + "'s record?",
                                               "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                teacherDAO.DeleteClassOfTeacher(tserial,tclass);
                LoadTeacher();
            }
            
        }

        private void delbatchofteacher_Click_1(object sender, EventArgs e)
        {
            int tserial = Convert.ToInt32(tserialbox.Text);
            string tname = tnamebox.Text;
            string temail = temailbox.Text;
            string tphone = tphonebox.Text;
            string taddress = taddressbox.Text;
            string tclass = teacherclasscombo.Text;
            string tbatch = tbatchcombo.Text;
            string tsub = teachersubcombo.Text;
            string tsubcode = tsubcodebox.Text;

            DialogResult result = MessageBox.Show("Do you want to remove Batch:" + tbatch + " of Class: "+tclass+ " from "+tname+"'s record?",
                                                "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                teacherDAO.DeleteBatchOfTeacher(tserial,tclass,tbatch);
                LoadTeacher();
            }
            
        }

        private void delsubofteacher_Click(object sender, EventArgs e)
        {
            int tserial = Convert.ToInt32(tserialbox.Text);
            string tname = tnamebox.Text;
            string temail = temailbox.Text;
            string tphone = tphonebox.Text;
            string taddress = taddressbox.Text;
            string tclass = teacherclasscombo.Text;
            string tbatch = tbatchcombo.Text;
            string tsub = teachersubcombo.Text;
            string tsubcode = tsubcodebox.Text;

            DialogResult result = MessageBox.Show("Do you want to remove Subject:" + tsub + " of Class: " + tclass + " from " + tname + "'s record?",
                                                "Warning..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                teacherDAO.DeleteSubjectOfTeacher(tserial, tsubcode,tsub,tclass);
                LoadTeacher();
            }
        }


       
        private void tdataview_SelectionChanged(object sender, EventArgs e)
        {
            if (tdataview.SelectedRows.Count == 1)
            {
                int idx = tdataview.SelectedRows[0].Index;
                tserialbox.Text = tdataview.Rows[idx].Cells[0].Value.ToString();
                tnamebox.Text = tdataview.Rows[idx].Cells[1].Value.ToString();
                teacherclasscombo.Text = tdataview.Rows[idx].Cells[2].Value.ToString();
                tbatchcombo.Text = tdataview.Rows[idx].Cells[3].Value.ToString();
                teachersubcombo.Text = tdataview.Rows[idx].Cells[4].Value.ToString();
                tsubcodebox.Text = tdataview.Rows[idx].Cells[5].Value.ToString();
                temailbox.Text = tdataview.Rows[idx].Cells[7].Value.ToString();
                tphonebox.Text = tdataview.Rows[idx].Cells[6].Value.ToString();
                taddressbox.Text = tdataview.Rows[idx].Cells[8].Value.ToString();
                tsalarybox.Text = tdataview.Rows[idx].Cells[9].Value.ToString();


            }
        }

        //!! -------------------------------- TEACHER tab ends ------------------------- !!//



        // --------------------------  RESULT tab starts ---------------------------- //
        private void LoadStudentResult()
        {
            stdresview.DataSource = resultDAO.GetStudentResult().Tables[0];
        }

        private void LoadStudentClass(string stdroll)
        {
            try
            {
                stdclassbox.Text = studentDAO.GetStudentClassWithId(stdroll).Tables[0].Rows[0]["ClassName"].ToString();
                feeclassbox.Text = studentDAO.GetStudentClassWithId(stdroll).Tables[0].Rows[0]["ClassName"].ToString();
            }
            catch (Exception)
            {

            }

        }

        private void LoadStudentBatch(string stdroll)
        {
            try
            {
                stdbatchbox.Text = studentDAO.GetStudentBatchWithId(stdroll).Tables[0].Rows[0]["BatchName"].ToString();
                feebatchbox.Text = studentDAO.GetStudentBatchWithId(stdroll).Tables[0].Rows[0]["BatchName"].ToString();
            }
            catch (Exception)
            {

            }

        }

        private void LoadStudentSubject(string classname)
        {
            try
            {
                stdsubnamecombo.DisplayMember = "SubName";
                stdsubnamecombo.ValueMember = "Subject";
                stdsubnamecombo.DataSource = studentDAO.GetStudentSubject(classname).Tables[0];
            }
            catch (Exception)
            {

            }
        }
        private void LoadStudentSerial(string stdroll)
        {
            try
            {
                stdserialbox.Text = studentDAO.GetStudentSerialWithId(stdroll).Tables[0].Rows[0]["SerialNo"].ToString();
            }
            catch (Exception)
            {

            }

        }
        private void stdrollbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stdsubnamecombo.Text = "";
                stdclassbox.Text = "";
                string stdroll = stdrollbox.Text;
                LoadStudentClass(stdroll);
                LoadStudentBatch(stdroll);
                LoadStudentSerial(stdroll);
            }catch(Exception)
            {

            }
            
        }
        private void stdclassbox_TextChanged(object sender, EventArgs e)
        {
            string classname = stdclassbox.Text;
            LoadStudentSubject(classname);
        }

        private void stdsubnamecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stdsubnamecombo.SelectedIndex > -1)
            {

                String subname = stdsubnamecombo.Text;
                String classname = stdclassbox.Text;
                LoadStudentSubjectCode(subname, classname);

            }
        }

        private void LoadStudentSubjectCode(string subname, string classname)
        {
            try
            {
                stdsubcode.Text = studentDAO.GetStudentSubjectCode(subname, classname).Tables[0].Rows[0]["SubCode"].ToString();
            }
            catch (Exception)
            {

            }
        }


        private void LoadMarkSheet(string roll, string exam)
        {
            marksview.DataSource = resultDAO.GetMarkSheet(roll,exam).Tables[0];
        }

        private void LoadTotalMarks(string roll, string exam)
        {
            try
            {

                totalmarkbox.Text =Convert.ToString(resultDAO.GetTotalExamMarks(roll, exam).Tables[0].Rows[0]["TotalMarks"]);
                obtainmarkbox.Text =Convert.ToString(resultDAO.GetTotalObtainedMarks(roll, exam).Tables[0].Rows[0]["TotalMarks"]);
            }
            catch(Exception)
            {

            }
        }

        private void import_Click(object sender, EventArgs e)
        {

            string selectedpath;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files (*.*)|*.*";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedpath = ofd.FileName;
                MessageBox.Show(selectedpath);
                resultDAO.ImportResult(selectedpath);

            }


            LoadStudentResult();
        }
        private void stdresaddbtn_Click(object sender, EventArgs e)
        {
           
            string stdid = stdrollbox.Text;
            //int serialno = Convert.ToInt32(stdserialbox.Text);
            string classname = stdclassbox.Text;
            string batchname = stdbatchbox.Text;
            string subname = stdsubnamecombo.Text;
            string subcode = stdsubcode.Text;
            string examtype = stdexamtypebox.Text;
            string exammarks = stdfullmarkbox.Text;
            string obtain = stdobtainedmarkbox.Text;

            resultDAO.AddResult(new ResultDTO(stdid, classname, batchname, subname, subcode, examtype, exammarks, obtain));
            LoadStudentResult();


        }

        private void stdresupdatebtn_Click(object sender, EventArgs e)
        {
            string examid = stdexamidbox.Text;
            string stdid = stdrollbox.Text;
            string classname = stdclassbox.Text;
            string batchname = stdbatchbox.Text;
            string subname = stdsubnamecombo.Text;
            string subcode = stdsubcode.Text;
            string examtype = stdexamtypebox.Text;
            string exammarks = stdfullmarkbox.Text;
            string obtain = stdobtainedmarkbox.Text;

            resultDAO.UpdateResult(examid, stdid, classname, batchname, subname, subcode, examtype, exammarks, obtain);
            LoadStudentResult();


        }

        private void stdexamtypecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stdexamtypecombo.SelectedIndex > -1)
            {
                if (stdexamtypecombo.SelectedIndex.ToString() == "Final" || stdexamtypecombo.SelectedIndex.ToString() == "final")
                {
                    string stdroll = stdressearchrollbox.Text;
                    string examtype = stdexamtypecombo.Text;
                    LoadMarkSheet(stdroll, examtype);
                    LoadTotalMarks(stdroll, examtype);
                }
                else
                {
                    string roll = stdressearchrollbox.Text;
                    string exam = stdexamtypecombo.Text;
                    LoadMarkSheet(roll, exam);
                    LoadTotalMarks(roll, exam);
                }

            }

        }

        private void allstdresdelbtn_Click(object sender, EventArgs e)
        {
            string examid = stdexamidbox.Text;
            resultDAO.DeleteResult();
            LoadStudentResult();
        }

        private void stdressearchrollbox_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string stdroll = stdressearchrollbox.Text;
                LoadExamTypeComboBoxItem(stdroll);
            }
            catch (Exception)
            {

            }
        }

        private void marksview_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void stdresview_SelectionChanged(object sender, EventArgs e)
        {
            if (stdresview.SelectedRows.Count == 1)
            {
                int idx = stdresview.SelectedRows[0].Index;
                stdexamidbox.Text = stdresview.Rows[idx].Cells[0].Value.ToString();
                stdrollbox.Text = stdresview.Rows[idx].Cells[1].Value.ToString();
                stdclassbox.Text = stdresview.Rows[idx].Cells[2].Value.ToString();
                stdbatchbox.Text = stdresview.Rows[idx].Cells[3].Value.ToString();
                stdsubnamecombo.Text = stdresview.Rows[idx].Cells[4].Value.ToString();
                stdsubcode.Text = stdresview.Rows[idx].Cells[5].Value.ToString();
                stdexamtypebox.Text = stdresview.Rows[idx].Cells[6].Value.ToString();
                stdfullmarkbox.Text = stdresview.Rows[idx].Cells[7].Value.ToString();
                stdobtainedmarkbox.Text = stdresview.Rows[idx].Cells[8].Value.ToString();


            }
        }



        //!! --------------------------- RESULT tab ends ----------------------------- !!//




        //----------------- teacher SALARY tab starts -------------------------//


        //teacher salary status combo box item
        private void LoadSalaryStatus()
        {
            salarystatuscombo.Items.Add("Paid");
            salarystatuscombo.Items.Add("Pending");
            feestatuscombo.Items.Add("Paid");
            feestatuscombo.Items.Add("Pending");

        }

        //teacher salary month combo box item
        private void LoadSalaryMonth()
        {
            salarymonthcombo.Items.Add("Jan"); feemonthcombo.Items.Add("Jan");
            salarymonthcombo.Items.Add("Feb"); feemonthcombo.Items.Add("Feb");
            salarymonthcombo.Items.Add("Mar"); feemonthcombo.Items.Add("Mar");
            salarymonthcombo.Items.Add("Apr"); feemonthcombo.Items.Add("Apr");
            salarymonthcombo.Items.Add("Mau"); feemonthcombo.Items.Add("Mau");
            salarymonthcombo.Items.Add("Jun"); feemonthcombo.Items.Add("Jun");
            salarymonthcombo.Items.Add("Jul"); feemonthcombo.Items.Add("Jul");
            salarymonthcombo.Items.Add("Aug"); feemonthcombo.Items.Add("Aug");
            salarymonthcombo.Items.Add("Sep"); feemonthcombo.Items.Add("Sep");
            salarymonthcombo.Items.Add("Oct"); feemonthcombo.Items.Add("Oct");
            salarymonthcombo.Items.Add("Nov"); feemonthcombo.Items.Add("Nov");
            salarymonthcombo.Items.Add("Dec"); feemonthcombo.Items.Add("Dec");
        }


        //show detail from TeacherSalary table in grid view
        private void LoadTeacherSalaryRecord()
        {
            salarydataview.DataSource = teacherSalaryDAO.GetTeacherSalaryRecord().Tables[0];
        }


        //after just giving id this method will fill salary box of that teacher
        private void LoadSalary(string id)
        {
            try
            {
                salarybox.Text = teacherSalaryDAO.GetSalary(id).Tables[0].Rows[0]["Salary"].ToString();
            }
            catch (Exception)
            {
            }

        }


        private void salaryaddbtn_Click(object sender, EventArgs e)
        {
            if(salaryidbox.Text != "" && tsalaryidbox.Text!="" && salarybox.Text!="" && salarymonthcombo.Text!="" && tsalaryyearbox.Text != "" && salarystatuscombo.Text!="")
            {
                string id = tsalaryidbox.Text;
                string salary = salarybox.Text;
                string month = salarymonthcombo.Text;
                string year = tsalaryyearbox.Text;
                string status = salarystatuscombo.Text;
                teacherSalaryDAO.AddTeacherSalary(new TeacherSalaryDTO(id, salary, month, year, status));
                LoadTeacherSalaryRecord();
            }
            else
            {
                MessageBox.Show("Please Provide All The Information Correctly!");
            }
           
        }

        private void salaryinfoupdate_Click(object sender, EventArgs e)
        {
            string sid = salaryidbox.Text;
            string id = tsalaryidbox.Text;
            string salary = salarybox.Text;
            string month = salarymonthcombo.Text;
            string status = salarystatuscombo.Text;
            teacherSalaryDAO.UpdateTeacherSalaryRecord(sid, id, salary, month, status);
            LoadTeacherSalaryRecord();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sid = salaryidbox.Text;
            teacherSalaryDAO.DeleteTeacherSalaryRecord(sid);
            LoadTeacherSalaryRecord();
        }

        private void tsalaryidbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                salaryidbox.Text = "";
                salarybox.Text = "";
                salarymonthcombo.Text = "";
                tsalaryyearbox.Text = "";
                salarystatuscombo.Text = "";
                string id = tsalaryidbox.Text;
                LoadSalary(id);
            }
            catch(Exception)
            {
                
            }
            
        }



        private void salarydataview_SelectionChanged(object sender, EventArgs e)
        {
            if (salarydataview.SelectedRows.Count == 1)
            {
                int idx = salarydataview.SelectedRows[0].Index;
                tsalaryidbox.Text = salarydataview.Rows[idx].Cells[0].Value.ToString();
                salarybox.Text = salarydataview.Rows[idx].Cells[1].Value.ToString();
                salarymonthcombo.Text = salarydataview.Rows[idx].Cells[2].Value.ToString();
                tsalaryyearbox.Text = salarydataview.Rows[idx].Cells[3].Value.ToString();
                salarystatuscombo.Text = salarydataview.Rows[idx].Cells[4].Value.ToString();
                salaryidbox.Text = salarydataview.Rows[idx].Cells[5].Value.ToString();
            }
        }
        //!!---------------------teacher SALARY tab ends----------------------------!!//






        private void LoadClassCode(string classname)
        {
            codebox.Text = classDAO.GetClassCode(classname).Tables[0].Rows[0]["ClassCode"].ToString();
            classcode.Text = classDAO.GetClassCode(classname).Tables[0].Rows[0]["ClassCode"].ToString();
            subcodecombo.Text = classDAO.GetClassCode(classname).Tables[0].Rows[0]["ClassCode"].ToString();
        }

        private void LoadSubjectCode(string subname,string classname)
        {
            tsubcodebox.Text = subjectDAO.GetSubjectCode(subname,classname).Tables[0].Rows[0]["SubCode"].ToString();
        }
 

       

        private void subclasscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            subcodecombo.Text = "--subject code--";
            
            if (subclasscombo.SelectedIndex > -1)
            {

                String classname = subclasscombo.Text;
                LoadClassCode(classname);
            }
        }


        

        private void teacherclasscombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //teachersubcombo.Text = "--subject name--";

            if (teacherclasscombo.SelectedIndex > -1)
            {

                String classname = teacherclasscombo.Text;
                teachersubcombovalue = classname;
                LoadSubjectName(classname);
                LoadBatchComboBox(classname);
               
                
            }
        }

        private void teachersubcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsubcodebox.Text = "";

            if (teachersubcombo.SelectedIndex > -1)
            {

                String subname = teachersubcombo.Text;
                LoadSubjectCode(subname,teachersubcombovalue);

            }
        }



        private void printStdInfo_Click(object sender, EventArgs e)
        {

        }     

        private void taddressbox_TextChanged(object sender, EventArgs e)
        {

        }

       

       

        private void cbpage_Click(object sender, EventArgs e)
        {

        }

        private void printresbtn_Click(object sender, EventArgs e)
        {
            string roll = stdressearchrollbox.Text;
            string exam = stdexamtypecombo.Text;
            ResultPrintPreview resultPrintPreview = new ResultPrintPreview(roll,exam);
            resultPrintPreview.ShowDialog();
            
        }

        private void resultpage_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataviewclass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void batchpage_Click(object sender, EventArgs e)
        {

        }

        private void subjectpage_Click(object sender, EventArgs e)
        {

        }

        private void studentpage_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void studentphonebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void teacherpage_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }
        string inputFileName;
        private void generateExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                sfd.FileName = "ExcelFile";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    
                    inputFileName = sfd.FileName;
                    CreateExcelFile(inputFileName);
                    
                   
                }
                else
                {
                    //do nothing
                }
            }
            
            
        }

        private void OpenFileExplorer(string filename)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Filter = "Excel Workbook|*.xlsx";
            ofd1.FilterIndex = 1;
            ofd1.FileName = "filename";
            ofd1.ShowDialog();
        }
        private void CreateExcelFile(String filename)
        {
            string fileTest = filename;

            Excel1.Application oApp;
            Excel1.Worksheet oSheet;
            Excel1.Workbook oBook;

            oApp = new Excel1.Application();
            oBook = oApp.Workbooks.Add();
            oSheet = (Excel1.Worksheet)oBook.Worksheets.get_Item(1);

            oSheet.Cells[1, 1] = "ExamId";
            oSheet.Cells[1, 2] = "StudentId";
            oSheet.Cells[1, 3] = "ClassName";
            oSheet.Cells[1, 4] = "BatchName";
            oSheet.Cells[1, 5] = "SubName";
            oSheet.Cells[1, 6] = "SubCode";
            oSheet.Cells[1, 7] = "ExamType";
            oSheet.Cells[1, 8] = "ExamMarks";
            oSheet.Cells[1, 9] = "ObtainedMarks";

            oBook.SaveAs(fileTest);
          
            
            oBook.Close();
            oApp.Quit();
            DialogResult result = MessageBox.Show("File Created Successfully!");
            if (result == DialogResult.OK)
            {
                OpenFileExplorer(fileTest);
            }
           
        }

        private void LoadStudentFee()
        {
            feedataview.DataSource = studentFeeDAO.GetStudentFeeRecord().Tables[0];
        }
        private void feeaddbtn_Click(object sender, EventArgs e)
        {
            string stdid = feerollbox.Text;
            string classname= feeclassbox.Text;
            string batchname = feebatchbox.Text;
            string monthlyfee = feemoneybox.Text;
            string feemonth =feemonthcombo.Text;
            string feeyear = feeyearbox.Text;
            string feestatus = feestatuscombo.Text;
            //classDAO.CreateClass(new ClassDTO(classname, classcode, classfee));
            studentFeeDAO.AddStudentFee(new StudentFeeDTO(stdid,classname,batchname,monthlyfee,feemonth,feeyear,feestatus));
            LoadStudentFee();

        }

        private void feerollbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string stdroll = feerollbox.Text;
                LoadStudentClass(stdroll);
                LoadStudentBatch(stdroll);
                LoadStudentFee(stdroll);
            }catch(Exception)
            {

            }
            

        }

        private void LoadStudentFee(string stdroll)
        {
            try
            {
                feemoneybox.Text = studentDAO.GetStudentFeeWithId(stdroll).Tables[0].Rows[0]["StdFee"].ToString();
            }
            catch (Exception)
            {

            }

        }

        private void feedataview_SelectionChanged(object sender, EventArgs e)
        {
            if (feedataview.SelectedRows.Count == 1)
            {

                int idx = feedataview.SelectedRows[0].Index;
                feerollbox.Text = feedataview.Rows[idx].Cells[0].Value.ToString();
                feeclassbox.Text = feedataview.Rows[idx].Cells[1].Value.ToString();
                feebatchbox.Text = feedataview.Rows[idx].Cells[2].Value.ToString();
                feemoneybox.Text = feedataview.Rows[idx].Cells[3].Value.ToString();
                feemonthcombo.Text = feedataview.Rows[idx].Cells[4].Value.ToString();
                feeyearbox.Text = feedataview.Rows[idx].Cells[5].Value.ToString();
                feestatuscombo.Text = feedataview.Rows[idx].Cells[6].Value.ToString();
                feeidbox.Text = feedataview.Rows[idx].Cells[7].Value.ToString();


            }
        }

        private void feedelbtn_Click(object sender, EventArgs e)
        {
            int feeid =Convert.ToInt32(feeidbox.Text);
            studentFeeDAO.DeleteFee(feeid);
            LoadStudentFee();
        }

        private void feeupdatebtn_Click(object sender, EventArgs e)
        {
            int feeid = Convert.ToInt32(feeidbox.Text);
            string stdid = feerollbox.Text;
            string classname = feeclassbox.Text;
            string batchname = feebatchbox.Text;
            string monthlyfee = feemoneybox.Text;
            string feemonth = feemonthcombo.Text;
            string feeyear = feeyearbox.Text;
            string feestatus = feestatuscombo.Text;
            
            studentFeeDAO.UpdateFee(feeid,stdid, classname, batchname, monthlyfee, feemonth, feeyear, feestatus);
            LoadStudentFee();
        }

        private void LoadPendingFee(string classname)
        {
            feedataview.DataSource = studentFeeDAO.GetPendingFee(classname).Tables[0];
        }
        private void viewpendingfeebtn_Click(object sender, EventArgs e)
        {
            string classname = pendingfeeclassbox.Text;
            LoadPendingFee(classname);
        }

        private void viewallfeebtn_Click(object sender, EventArgs e)
        {
            LoadStudentFee();
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void pendingfeeclassbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printreceiptbtn_Click(object sender, EventArgs e)
        {
            if (feedataview.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please Select a Row from The Grid View of Student Fee");
            }
            else
            {
                string feeid = feeidbox.Text;
                MoneyReceiptPrintPreview moneyReceiptPrintPreview = new MoneyReceiptPrintPreview(feeid);
                moneyReceiptPrintPreview.ShowDialog();
            }
            

        }

        private void stdreceiptprintrollbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void anyresdelbtn_Click(object sender, EventArgs e)
        {
            string examid = stdexamidbox.Text;
            resultDAO.DeleteAnyResult(examid);
            LoadStudentResult();
        }

        private void LoadTeacherSalaryWithId(string id)
        {
            salarydataview.DataSource = teacherSalaryDAO.GetTeacherSalaryWithId(id).Tables[0];
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tid = textBox3.Text;
                LoadTeacherSalaryWithId(tid);
            }
            catch (Exception)
            {

            }
        }

        private void printreceiptbtn2_Click(object sender, EventArgs e)
        {
            if (feedataview.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please Select a Row from The Grid View of Student Fee");
            }
            else
            {
                string feeid = feeidbox.Text;
                MoneyReceiptPrintPreview moneyReceiptPrintPreview = new MoneyReceiptPrintPreview(feeid);
                moneyReceiptPrintPreview.ShowDialog();
            }
        }
}

       

       

        
       


       

      

        
     
    }
