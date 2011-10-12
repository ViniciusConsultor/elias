using System;
namespace Alfa.Core.Exception
{
    public interface IHandlerException
    {
        void TryException(System.Exception ex);
        void DisplayMessage(String message);
        void Log(string message);
    }
}
