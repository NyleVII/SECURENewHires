using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Hires_Email
{
    class Counter
    {
        int count = 0;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void incrementCount()
        {
            this.count++;
        }

        public void decrementCount()
        {
            this.count--;
        }
    }
}
