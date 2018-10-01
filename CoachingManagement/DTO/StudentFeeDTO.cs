using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class StudentFeeDTO
    {
        int feeid;
        string studentid, classname, batchname, monthlyfee, feemonth, feeyear, feestatus;

        public StudentFeeDTO(string studentid, string classname, string batchname, string monthlyfee, string feemonth, string feeyear, string feestatus)
        {
           // this.feeid = feeid;
            this.studentid = studentid;
            this.classname = classname;
            this.batchname = batchname;
            this.monthlyfee = monthlyfee;
            this.feemonth = feemonth;
            this.feeyear = feeyear;
            this.feestatus = feestatus;
        }


        public int FEEID
        {
            get { return feeid; }
            set { feeid = value; }
        }
        public string STDID
        {
            get { return studentid; }
            set { studentid = value; }
        }
        public string CLASS
        {
            get { return classname; }
            set { classname = value; }
        }
        public string BATCH
        {
            get { return batchname; }
            set { batchname = value; }
        }
        public string MONTHLYFEE
        {
            get { return monthlyfee; }
            set { monthlyfee = value; }
        }
        public string FEEMONTH
        {
            get { return feemonth; }
            set { feemonth= value; }

        }
        public string FEEYEAR
        {
            get { return feeyear; }
            set { feeyear = value; }
        }

        public string FEESTATUS
        {
            get { return feestatus; }
            set { feestatus = value; }
        }
    }
}
