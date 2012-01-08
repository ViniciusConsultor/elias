using System;
using System.Collections.Generic;
using Alfa.Core.Entity;


namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class UnidadeSaude : EntityBase
    {

        #region "Atributos"
        private IList<Notificacao> notificacaoList = new List<Notificacao>();
        private IList<Usuario> usuarioList = new List<Usuario>();
        #endregion

        public UnidadeSaude()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual int Version { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual IList<Notificacao> NotificacaoLista
        {
            get { return this.notificacaoList; }
            set { this.notificacaoList = value; }
        }
        public virtual IList<Usuario> UsuarioLista
        {
            get { return this.usuarioList; }
            set { this.usuarioList = value; }
        }
        #endregion

    }
}
