
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arithmetic
{
    public abstract class Test1
    {
        protected Test1()
        {
            Console.WriteLine("a");
        }

        protected Test1(string str):this()
        {
            Console.WriteLine(str);
        }
    }

    class Test:Test1
    {
        public Test()
        {
            Console.WriteLine("A");
        }

        public Test(string str) : this()
    {
        Console.WriteLine(str);
    }
    }
}
