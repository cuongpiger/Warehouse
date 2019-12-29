using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Operation
    {
        public string Description { get; set; }
        public StringProcessor Processor { get; set; }
        public StringProcessorArgs Args { get; set; }
        public Window ConfigScreen { get; set; }

        public string Invoke(string hayStack)
        {
            return Processor(hayStack, Args);
        }
    }

    public class StringProcessorArgs
    {

    }

    public class MultiplyStringProcessorArgs : StringProcessorArgs
    {
        public int Count { get; set; }
    }

    public class RemoveStringProcessorArgs : StringProcessorArgs
    {
        public int StartIndex { get; set; }
        public int Count { get; set; }
    }

    public class ReplaceStringProcessorArgs : StringProcessorArgs
    {
        public string Needle { get; set; }
        public string Hammer { get; set; }
    }

    public delegate string StringProcessor(
        string origin,
        StringProcessorArgs args);

    

}
