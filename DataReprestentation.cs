using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class DataReprestentation
    {
        public class WindsWithDate
        {
            public DateTime datetime;
            public DataModel.Wind winds;
            public WindsWithDate(DateTime datetime, DataModel.Wind winds)
            {
                this.datetime = datetime;
                this.winds = winds;
            }
        }
        public class MainWithDate
        {
            public DataModel.Main mains;
            public DateTime dateTime;
            public MainWithDate(DataModel.Main m, DateTime dateTime)
            {
                this.dateTime = dateTime;
                this.mains = m;
            }
        }
    }
}
