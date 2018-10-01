using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class SubjectDTO
    {
        private string classname,classcode,subname,subcode;

        public SubjectDTO(string classname,string classcode,string subname,string subcode)
        {
            this.classname = classname;
            this.classcode = classcode;
            this.subname =subname;
            this.subcode = subcode;
        }
        public string CLASSNAME
        {
            get { return classname; }
            set { classname = value; }
        }
        public string CLASSCODE
        {
            get { return classcode; }
            set { classcode = value; }
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
    }
}
