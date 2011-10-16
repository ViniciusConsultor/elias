using System;
using System.Collections.Generic;
namespace Alfa.Core.Validation
{
    public interface IValidator
    {
        void Assert(bool condition, string message);
        void Assert(bool condition, string message, bool imediateValidate);
        void Assert(IEnumerable<string> messages, bool imediateValidate);

        IEnumerable<string> GetAssertsInvalids();

        bool HasErros();
        
        void Validate();
    }
}
