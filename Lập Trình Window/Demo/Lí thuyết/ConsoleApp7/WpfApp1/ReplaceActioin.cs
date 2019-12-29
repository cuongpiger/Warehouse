using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ReplaceAction : Action
    {
        public string Name => "The seeker";

        public StringProcessor Processor => replace;
        public StringProcessorArgs Args { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        static string replace(
            string origin, StringProcessorArgs args)
        {
            var myArgs = args as ReplaceStringProcessorArgs;
            var needle = myArgs.Needle;
            var hammer = myArgs.Hammer;

            return origin.Replace(needle, hammer);
        }

        public class ReplaceStringProcessorArgs :
            StringProcessorArgs
        {
            public string Needle { get; set; }
            public string Hammer { get; set; }
        }
    }
}
