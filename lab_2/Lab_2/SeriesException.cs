using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class MyException
    {
        public class MyExceptions : Exception
        {
            public MyExceptions() : base() { }
            public MyExceptions(string s) : base(s) { }
        }
    }
}
