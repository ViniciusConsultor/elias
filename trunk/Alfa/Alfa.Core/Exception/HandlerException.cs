using Alfa.Core.Container;
using Alfa.Core.Unit;
using Castle.Core.Logging;

namespace Alfa.Core.Exception
{
    public class HandlerException : IHandlerException
    {
        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
        private IHandlerMessage handlerMessage = DefaultHandlerMessage.Instance;
        public IHandlerMessage HandlerMessage
        {
            get { return handlerMessage; }
            set { handlerMessage = value; }
        }
       
        public void TryException(System.Exception ex)
        {
            RollbackTransaction();
            DisplayMessage(GetMessage(ex));
            LogError(ex);
        }
        private void DisplayMessage(string message)
        {
            HandlerMessage.Show(message);            
        }
        public void Log(string message)
        {
            Logger.Error(message);
        }

        private void LogError(System.Exception ex)
        {
            if (!BusinessRuleViolated(ex))
                Logger.Error(ex.Message);
        }
        private bool BusinessRuleViolated(System.Exception ex)
        {
            return ex.GetType() == typeof(BussinessException);
        }
        private string GetMessage(System.Exception ex)
        {
            string message = "Não foi possível completar esta operação.";

            if (BusinessRuleViolated(ex)) return (ex.Message);

            return message;
        }
        private void RollbackTransaction()
        {
            try
            {
                Locator.GetComponet<IUnitOfWork>().Rollback();
            }
            catch (System.Exception ex)
            {
                Logger.Error("Não foi possível desfazer a transação. Detalhes:" + ex.Message);
            }
        }
    }
}
