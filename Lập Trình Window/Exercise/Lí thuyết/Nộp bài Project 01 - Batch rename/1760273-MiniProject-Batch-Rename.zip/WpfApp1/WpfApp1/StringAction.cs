﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public delegate string StringProcessor(string origin);

    public interface StringAction
    {
       
        string Name { get;}
        StringProcessor Processor { get; }
        StringArgs Args { get; set; }

        StringAction Clone();
        void ShowEditDialog();
    }

    public interface StringArgs
    {
        string Details { get; }
    }
}
