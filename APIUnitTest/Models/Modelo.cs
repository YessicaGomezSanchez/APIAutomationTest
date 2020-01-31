using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUnitTest
{
    public class Modelo
    {
        public System.Int32 count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Results> results { get; set; }
    }

    public class Results
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
