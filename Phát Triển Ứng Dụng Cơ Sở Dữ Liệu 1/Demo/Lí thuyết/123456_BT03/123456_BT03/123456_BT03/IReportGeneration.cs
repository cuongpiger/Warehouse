using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class IReportGeneration
    {
        public virtual void GenerateReport(string line, ref StreamWriter file)
        {
            // From base
        }
    }
}
