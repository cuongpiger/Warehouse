using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    delegate string StringProcessor(
        string origin, StringProcessorArgs args);
    class StringProcessorArgs { }

    interface Action
    {
        string Name { get; }
        StringProcessor Processor { get; }
        StringProcessorArgs Args { get; set; }
    }
}
