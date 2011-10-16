using Castle.DynamicProxy;
using Alfa.Core.Exception;
using Castle.Core.Logging;

namespace Alfa.Core.AOP
{
    public class Interceptor : IInterceptor
    {
        private IHandlerException handlerException = DefaultHandlerException.Instance;
        
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
                //todo: validar retorno
                invocation.ReturnValue = false;
                handlerException.TryException(ex);
            }
        }
    }
}
