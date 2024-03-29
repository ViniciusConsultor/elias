﻿using Alfa.Core.Container;
using Alfa.Core.Unit;
using Castle.Core.Logging;
using NHibernate;

namespace Alfa.Core.Exception
{
    public class DefaultHandlerException : IHandlerException
    {
        #region Singleton
        private static volatile DefaultHandlerException instance;
        private static object syncRoot = new object();

        private DefaultHandlerException()
        { }

        public static DefaultHandlerException Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DefaultHandlerException();
                    }
                }

                return instance;
            }
        }
        #endregion

        private ILogger logger = NullLogger.Instance;
        public ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
        private IHandlerMessage handlerMessage = DefaultHandlerMessage.Instance;
        
        public DefaultHandlerException(IHandlerMessage phandlerMessage)
        {
            handlerMessage = phandlerMessage;
        }

        public void TryException(System.Exception ex)
        {
            RollbackTransaction();
            DisplayMessage(GetMessage(ex));
            LogError(ex);
        }
        private void DisplayMessage(string message)
        {
            handlerMessage.Show(message);
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
            return ex.GetType() == typeof(BusinessException);
        }

        private string GetMessage(System.Exception ex)
        {
            string message = "Não foi possível completar esta operação.";

            if (BusinessRuleViolated(ex)) return (ex.Message);
            if (ConcorrencyViolated(ex)) return "Este registro foi alterado por outra transação. Tente novamente.";

            return message;
        }

        private bool ConcorrencyViolated(System.Exception ex)
        {
            return ex.GetType() == typeof(StaleObjectStateException);
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
