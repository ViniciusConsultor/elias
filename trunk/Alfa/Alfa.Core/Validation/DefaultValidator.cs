using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfa.Core.Validation
{
    public sealed class DefaultValidator : IValidator
    {



        public void Assert(bool condition, string message)
        {
            throw new NotImplementedException();
        }

        public void Assert(bool condition, string message, bool imediateValidate)
        {
            throw new NotImplementedException();
        }

        public void Assert(IList<string> messages, bool imediateValidate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAssertsInvalids()
        {
            throw new NotImplementedException();
        }

        public bool HasErros()
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
