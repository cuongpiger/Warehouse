using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Student
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Generic - Template - thay the
            //List<int> list = new List<int>()
            //{
            //    4, 5, 6, 7, 8
            //};
            //List<Student> list2 = new List<Student>();
            //List<Item> list3 = new List<Item>();

            ArrayList list = new ArrayList();
            list.Add("10");
            list.Add("Hello world");
            list.Add("new Student()");
            list.Add("new int[] { 4, 5, 1, 10 }");

            var item = (String) list[2];
        }
    }
}
