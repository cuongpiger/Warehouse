using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class TxtReportGeneraion : IReportGeneration
    {
        public override void GenerateReport(string line, ref StreamWriter file)
        {
            file.WriteLine(line);
        }
    }
}
