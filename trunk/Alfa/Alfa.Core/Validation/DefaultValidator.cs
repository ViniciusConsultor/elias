using System;
using System.Collections.Generic;
using Alfa.Core.Validation;
using Alfa.Core.Exception;
using System.Configuration;
using System.Linq; 

namespace Alfa.Core.Validation
{
    public class DefaultValidator : IValidator
    {

        #region singleton
        private static volatile DefaultValidator instance;
        private static object syncRoot = new Object();

        private DefaultValidator()
        { }

        public static DefaultValidator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DefaultValidator();
                    }
                }

                return instance;
            }
        }
        #endregion
        
        private List<String> mAsserts = new List<string>();

        /// <summary>Valida se as expressões inseridas são válidas</summary>
        /// <exception cref="">SaudeException. Caso as condiçoes não sejam satisfeitas. </exception>
        public void Validate()
        {
            if (HasErros())
            {
                throw new BussinessException(GetMessages());
            }
        }

        public bool HasErros()
        {
            return mAsserts.Count > 0;
        }

        public IEnumerable<String> GetAssertsInvalids()
        {
            return mAsserts;
        }

        /// <summary>
        /// A partir do teste realizado, caso a condição não seja satisfeita, adiciona a mensagem na lista de erros
        /// </summary>
        /// <param name="condition">Condição que deve ser satisfeita pela regra do negócio</param>
        /// <param name="message">Mensagem a ser disparada, caso a condição não seja satisfeita</param>
        public void Assert(bool condition, string message)
        {
            if (!condition)
                mAsserts.Add(message);
        }
        public void Assert(bool condition, string message, bool imediateValidate)
        {
            Assert(condition, message);
            if (imediateValidate)
                Validate();
        }
        public void Assert(IEnumerable<string> messages, bool imediateValidate)
        {
            if (messages == null || messages.Count()  == 0) return;
            bool condition = false;
            foreach (string message in messages)
                Assert(condition, message);

            if (imediateValidate)
                Validate();
        }

        private string GetMessages()
        {
            string allMessagems = "";
            string newLine = GetNewLine();

            foreach (string message in mAsserts)
                allMessagems += message + newLine;

            mAsserts.Clear();
            return allMessagems;
        }

        private string GetNewLine()
        {
            if (ConfigurationManager.AppSettings["NEW_LINE"] != null)
                return ConfigurationManager.AppSettings["NEW_LINE"];//.ToString();

            //if (System.Web.HttpContext.Current != null) return "<br/>";
            return "\\n";
        }

    }
}
