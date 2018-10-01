using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class ClassDTO
    {
        private string classname,classcode,classfee;

        public ClassDTO(string classname,string classcode,string classfee)
        {
            this.classname = classname;
            this.classcode = classcode;
            this.classfee = classfee;
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

        public string CLASSFEE
        {
            get { return classfee; }
            set { classfee = value; }
        }
    }
}
