using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class ResultDTO
    {

        private string  stdid, classname, batchname, subname, subcode, examtype, exammarks, obtainedmarks;
        
        public ResultDTO(string stdid, string classname, string batchname, string subname, string subcode, string examtype, string exammarks, string obtainedmarks)
        {
            this.stdid = stdid;
            this.classname = classname;
            this.batchname = batchname;
            this.subname = subname;
            this.subcode = subcode;
            this.examtype = examtype;
            this.exammarks = exammarks;
            this.obtainedmarks = obtainedmarks;
        }

        public string STDID
        {
            get { return stdid; }
            set { stdid = value; }
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
        public string SUBNAME
        {
            get { return subname; }
            set { subname = value; }
        }
        public string SUBCODE
        {
            get { return subcode; }
            set { subcode = value; }
        }
        public string EXAMTYPE
        {
            get { return examtype; }
            set { examtype = value; }
        }
        public string EXAMMARKS
        {
            get { return exammarks; }
            set { exammarks = value; }
        }

        public string OBTAINEDMARKS
        {
            get { return obtainedmarks; }
            set { obtainedmarks = value; }
        }
    }
}
