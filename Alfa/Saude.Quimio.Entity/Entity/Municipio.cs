using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Municipio : EntityBase
    {

        #region "Atributos"
        private IList<Bairro> bairroList = new List<Bairro>();
        private IList<Endereco> enderecoList = new List<Endereco>();
        private IList<UnidadeSaude> unidadeSaudeList = new List<UnidadeSaude>();
        private IList<Usuario> usuarioList = new List<Usuario>();
        #endregion

        public Municipio()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<Bairro> BairroLista
        {
            get { return this.bairroList; }
            set { this.bairroList = value; }
        }
        public virtual IList<Endereco> EnderecoLista
        {
            get { return this.enderecoList; }
            set { this.enderecoList = value; }
        }
        public virtual IList<UnidadeSaude> UnidadeSaudeLista
        {
            get { return this.unidadeSaudeList; }
            set { this.unidadeSaudeList = value; }
        }
        public virtual IList<Usuario> UsuarioLista
        {
            get { return this.usuarioList; }
            set { this.usuarioList = value; }
        }
        #endregion
    }
}
