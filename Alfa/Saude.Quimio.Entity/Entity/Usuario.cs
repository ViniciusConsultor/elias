using System;
using System.Collections.Generic;
using Alfa.Core.Entity;


namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Usuario : EntityBase
    {

        #region "Atributos"
        private IList<Notificacao> notificacaoList = new List<Notificacao>();
        #endregion

        public Usuario()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual int? SqCa { get; set; }
        public virtual bool? Ativo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual int Version { get; set; }

        public virtual IList<Notificacao> NotificacaoLista
        {
            get { return this.notificacaoList; }
            set { this.notificacaoList = value; }
        }
        #endregion
    }
}
