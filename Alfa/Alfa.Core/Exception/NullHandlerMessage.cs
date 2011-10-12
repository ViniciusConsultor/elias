using System;

namespace Alfa.Core.Exception
{
    public sealed class NullHandlerMessage : IHandlerMessage
    {
        // Static members are 'eagerly initialized', that is,
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization
        private static readonly NullHandlerMessage _instance = new NullHandlerMessage();

        private NullHandlerMessage()
        { }

        public static NullHandlerMessage GetNullHandlerMessage()
        {
            return _instance;
        }

        public void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
