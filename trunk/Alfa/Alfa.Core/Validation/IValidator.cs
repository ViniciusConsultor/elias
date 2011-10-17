using System;
using System.Collections.Generic;
namespace Alfa.Core.Validation
{
    /// <summary>
    /// Interface IValidator prove contrato para avaliação de expressões
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Método assert assegura que uma condição foi satisfeita. 
        /// </summary>
        ///  <example>
        /// String pessoa = "";
        /// Assert(pessoa != "", "Informe um valor");
        /// </example>
        /// <param name="condition">condição a ser avaliada</param>
        /// <param name="message">Mensagem que deve ser disparada se a condição for avaliada como false.
        /// </param>
        void Assert(bool condition, string message);
        /// <summary>
        /// Método assert assegura que uma condição foi satisfeita. 
        /// </summary>
        /// <param name="condition">condição a ser avaliada</param>
        /// <param name="message">Mensagem que deve ser disparada se a condição for avaliada como false.</param>
        /// <param name="imediateValidate">Se o valor for true, avalia imediatamente se expressões foram satisfeitas</param>
        void Assert(bool condition, string message, bool imediateValidate);
        /// <summary>
        /// Método assert assegura que uma condição foi satisfeita. 
        /// </summary>
        /// <param name="messages">Lista de mensagens a ser disparadas </param>
        /// <param name="imediateValidate">Se o valor for true, avalia imediatamente se expressões foram satisfeitas</param>
        void Assert(IEnumerable<string> messages, bool imediateValidate);
        /// <summary>
        /// Lista de mensagens, cuja condição foi avaliada como false.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Erros();
        /// <summary>
        /// Avalia se alguma condição foi avaliada como false.
        /// </summary>
        /// <returns></returns>
        bool HasErros();
        /// <summary>
        /// Avalia condições submetidas e dispara uma exceção caso alguma condição seja avaliada como false.
        /// </summary>
        /// <exception cref="Alfa.Core.Exception.Business">Disparada se alguma expressão tiver sido avaliada como false</exception>
        void Validate();
    }
}
