using System;
namespace Alfa.Core.Exception
{
    public interface IHandlerException
    {
        void TryException(System.Exception ex);
        void Log(string message);
    }
}
