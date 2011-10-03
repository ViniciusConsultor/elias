using System;
namespace Alfa.Core.Exception
{
    public interface IHandlerException
    {
        void TratarException(System.Exception ex);
    }
}
