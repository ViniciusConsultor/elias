using System;
using System.Collections.Generic;
using Alfa.Core.Validation;
using Alfa.Core.Exception;

namespace Alfa.Core.Validation
{
    public class Validator : IValidator
    {
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

        public List<String> GetAssertsInvalids()
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
        public void Assert(IList<string> messages, bool imediateValidate)
        {
            if (messages == null || messages.Count == 0) return;
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
            if (System.Web.Configuration.WebConfigurationManager.AppSettings["NEW_LINE"] != null)
                return System.Web.Configuration.WebConfigurationManager.AppSettings["NEW_LINE"];//.ToString();

            if (System.Web.HttpContext.Current != null) return "<br/>";
            return "\n";
        }

    }
}
