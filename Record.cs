using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiiBalanceScale
{
    public class Record
    {
        public Int64 Ticks { get; set; }
        //public string Timestamp { get; set; }
        public string GravX { get; set; }
        public string GravY { get; set; }
    }
}
