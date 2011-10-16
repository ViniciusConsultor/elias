using System;
using Alfa.Core.Exception;
using Castle.DynamicProxy;

namespace Alfa.Core.AOP
{
    public class Interceptor : IInterceptor
    {
        private IHandlerException handlerException = DefaultHandlerException.Instance;

        public Interceptor()
        {

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
                if (invocation.Method.ReturnType.IsPrimitive) //tipos primitivos precisam ter o valor de retorno setado
                    invocation.ReturnValue = Activator.CreateInstance(invocation.Method.ReturnType);
                
                handlerException.TryException(ex);
            }
        }
    }
}
