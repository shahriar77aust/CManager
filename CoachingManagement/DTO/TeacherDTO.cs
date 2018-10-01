using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class TeacherDTO
    {
        private string tname,classname,subname,subcode,phone,email,address,tbatch,tsalary;
        private int id;
 
        public TeacherDTO(int id,string tname,string classname,string tbatch,string subname,string subcode,string email,string phone,string address,string tsalary)
        {
            this.id = id;
            this.tname = tname;
            this.classname = classname;
            this.tbatch = tbatch;
            this.subname = subname;
            this.subcode = subcode;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.tsalary = tsalary;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string TNAME
        {
            get { return tname; }
            set { tname = value; }
        }
        public string CLASS
        {
            get { return classname; }
            set { classname = value; }
        }
        public string TBATCH
        {
            get { return tbatch; }
            set { tbatch = value; }
        }
        public string SUBCODE
        {
            get { return subcode; }
            set { subcode = value; }
        }
        public string SUBNAME
        {
            get { return subname; }
            set { subname = value; }
        }
        public string TEMAIL
        {
            get { return email; }
            set { email = value; }
        }
        public string PHONE
        {
            get { return phone; }
            set { phone = value; }
        }
        public string ADDRESS
        {
            get { return address; }
            set { address = value; }
        }

        public string TSALARY
        {
            get { return tsalary; }
            set { tsalary = value; }
        }

    }
}
