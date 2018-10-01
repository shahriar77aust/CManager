using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingManagement
{
    class BatchDTO
    {
        private string batchname;
        private int maxbatchstd;
        public BatchDTO(string batchname,int maxbatchstd)
        {
            this.batchname = batchname;
            this.maxbatchstd = maxbatchstd;
        }

        

        public string BATCH
        {
            get { return batchname; }
            set { batchname = value; }
        }
        public int BATCHSTD
        {
            get { return maxbatchstd; }
            set { maxbatchstd = value; }
        }
    }
}
