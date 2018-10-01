using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class TeacherSalaryDTO
    {
        private string id, salary, month, year,status;


        public TeacherSalaryDTO(string id, string salary, string month,string year, string status)
        {
            this.id = id;
            this.salary = salary;
            this.month = month;
            this.year = year;
            this.status = status;
        }


        public string TID
        {
            get { return id; }
            set { id = value; }
        }
        public string TSALARY
        {
            get { return salary; }
            set { salary = value; }
        }
        public string TMONTH
        {
            get { return month; }
            set { month = value; }
        }

        public string TYEAR
        {
            get { return year; }
            set { year = value; }
        }
        public string TSTATUS
        {
            get { return status; }
            set { status = value; }

        }
    }
}
