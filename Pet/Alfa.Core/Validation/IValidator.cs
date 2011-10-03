using System;
using System.Collections.Generic;
namespace Alfa.Core.Validation
{
    public interface IValidator
    {
        void Assert(bool condition, string message);
        void Assert(bool condition, string message, bool imediateValidate);
        void Assert(IList<string> messages, bool imediateValidate);

        List<string> GetAssertsInvalids();

        bool HasErros();
        
        void Validate();
    }
}
