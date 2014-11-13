
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo
{
    public class MyGenesisTape : ITapeCassette
    {
        public string Artist
        {
            get { return "Genesis"; }
        }

        public string Album
        {
            get { return "City of Angels"; }
        }
    }
}
