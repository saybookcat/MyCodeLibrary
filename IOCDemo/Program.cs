using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new IocContainer();
            container.Register<SonyWalkman,SonyWalkman>();
            container.Register<ITapeCassette,MyGenesisTape>();

            var walkman = container.Resolve<SonyWalkman>();

            Console.WriteLine(walkman.Paly());


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
