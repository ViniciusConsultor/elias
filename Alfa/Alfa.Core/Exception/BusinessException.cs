using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfa.Core.Exception
{
    public class BusinessException : System.Exception
    {
        public BusinessException(string message) :
            base(message) { }
    }
}
