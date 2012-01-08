using System;
using System.Collections.Generic;
using Alfa.Core.Entity;


namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Bairro : EntityBase
    {

        #region "Atributos"
        private IList<Endereco> enderecoList = new List<Endereco>();
        #endregion

        public Bairro()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual Municipio Municipio { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<Endereco> EnderecoLista
        {
            get { return this.enderecoList; }
            set { this.enderecoList = value; }
        }
        #endregion
    }
}