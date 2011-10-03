using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfa.Core.Exception
{
    public class BussinessException : System.Exception
    {
        public BussinessException(string message) :
            base(message) { }
    }
}
