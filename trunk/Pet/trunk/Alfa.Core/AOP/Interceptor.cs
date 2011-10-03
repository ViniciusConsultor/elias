using Castle.DynamicProxy;
using Alfa.Core.Exception;
using Castle.Core.Logging;

namespace Alfa.Core.AOP
{
    public class Interceptor : IInterceptor
    {
        private IHandlerException handlerException;

        public Interceptor()
        {
            handlerException = new HandlerException();
        }
        public Interceptor(IHandlerException phandlerException)
        {
            handlerException = phandlerException;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception ex)
            {
                handlerException.TratarException(ex);
            }
        }
    }
}
