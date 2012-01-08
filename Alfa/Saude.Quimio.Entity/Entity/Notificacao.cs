using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Notificacao : EntityBase
    {

        #region "Atributos"
        private IList<Acompanhamento> acompanhamentoList = new List<Acompanhamento>();
        private IList<QuestionarioNotificacao> questionarioNotificacaoList = new List<QuestionarioNotificacao>();
        #endregion

        public Notificacao()
        {
        }


        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string NomeResponsavelPreenchimento { get; set; }
        public virtual string FuncaoResponsavelPreenchimento { get; set; }
        public virtual DateTime? DataPreenchimento { get; set; }
        public virtual DateTime? DataInicioTratamento { get; set; }
        public virtual bool? DrogaIsoniazida { get; set; }
        public virtual string OutrasDrogas { get; set; }
        public virtual bool? TransferidoOutraUnidade { get; set; }
        public virtual DateTime? DataInicioTratamentoOutraUnidade { get; set; }
        public virtual bool? NotificacaoExcluida { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual UnidadeSaude UnidadeSaude { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<Acompanhamento> AcompanhamentoLista
        {
            get { return this.acompanhamentoList; }
            set { this.acompanhamentoList = value; }
        }
        public virtual IList<QuestionarioNotificacao> QuestionarioNotificacaoLista
        {
            get { return this.questionarioNotificacaoList; }
            set { this.questionarioNotificacaoList = value; }
        }
        #endregion
    }
}
