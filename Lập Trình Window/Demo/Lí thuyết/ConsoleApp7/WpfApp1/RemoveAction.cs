using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RemoveAction : Action
    {
        public string Name => "The destroyer";

        public StringProcessor Processor => remove;

        static string remove(string origin, 
            StringProcessorArgs args)
        {
            var myArgs = args as RemoveStringProcessorArgs;
            var startIndex = myArgs.StartIndex;
            var count = myArgs.Count;
            return origin.Remove(startIndex, count);
        }

        public StringProcessorArgs Args { get; set; }

        public class RemoveStringProcessorArgs: StringProcessorArgs
        {
            public int StartIndex { get; set; }
            public int Count { get; set; }
        }

    }
}
