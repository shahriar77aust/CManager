using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class StudentDTO
    {
        private string clscode, stdname, stdinsta, stdclass, stdbatch, stdaddress, stdphone, gurphone, stdfee;
        private int serialno, stdyear;

        public StudentDTO(int serialno,string stdname,string stdinsta,string stdclass,string clscode,string stdbatch,
                          string stdaddress,string stdphone,string gurphone,string stdfee,int stdyear)
        {
            this.serialno = serialno;
            this.stdname = stdname;
            this.stdinsta = stdinsta;
            this.stdclass = stdclass;
            this.clscode = clscode;
            this.stdbatch = stdbatch;
            this.stdaddress = stdaddress;
            this.stdphone = stdphone;
            this.gurphone = gurphone;
            this.stdfee = stdfee;
            this.stdyear = stdyear;
        }

        public int SERIALNO
        {
            get { return serialno; }
            set { serialno = value; }
        }

        public string STDNAME
        {
            get { return stdname; }
            set { stdname = value; }
        }
        public string STDINSTA
        {
            get { return stdinsta; }
            set { stdinsta = value; }
        }
        public string STDCLASS
        {
            get { return stdclass; }
            set { stdclass = value; }
        }
        public string CLSCODE
        {
            get { return clscode; }
            set { clscode = value; }
        }
        public string STDBATCH
        {
            get { return stdbatch; }
            set { stdbatch = value; }
        }
        public string STDADDRESS
        {
            get { return stdaddress; }
            set { stdaddress = value; }
        }
        public string STDPHONE
        {
            get { return stdphone; }
            set { stdphone = value; }
        }
        public string GURPHONE
        {
            get { return gurphone; }
            set { gurphone = value; }
        }
        public string STDFEE
        {
            get { return stdfee; }
            set { stdfee = value; }
        }
        public int STDYEAR
        {
            get { return stdyear; }
            set { stdyear = value; }
        }

    }
}
