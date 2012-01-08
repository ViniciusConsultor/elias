using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 
    public partial class Questionario : EntityBase
    {

        #region "Atributos"
        private IList<QuestionarioNotificacao> questionarioNotificacaoList = new List<QuestionarioNotificacao>();
        #endregion

        public Questionario()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual int? Ordem { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public virtual OpcaoResposta OpcaoResposta { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<QuestionarioNotificacao> QuestionarioNotificacaoLista
        {
            get { return this.questionarioNotificacaoList; }
            set { this.questionarioNotificacaoList = value; }
        }
        #endregion
    }
}
