using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class QuestionarioNotificacao : EntityBase
    {

        #region "Atributos"
        #endregion

        public QuestionarioNotificacao()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual Notificacao Notificacao { get; set; }
        public virtual string Justificativa { get; set; }
        public virtual OpcaoResposta OpcaoResposta { get; set; }
        public virtual int Version { get; set; }
        #endregion
    }
}
