
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    class MySetTape:ITapeCassette
    {
        public string Artist
        {
            get { return "MySet"; }
        }

        public string Album
        {
            get { return "Personal preferences"; }
        }
    }
}
