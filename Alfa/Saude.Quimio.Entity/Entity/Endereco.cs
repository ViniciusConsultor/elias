using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 
    public partial class Endereco : EntityBase
    {

        #region "Atributos"
        #endregion

        public Endereco()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Bairro Bairro { get; set; }
        public virtual int Version { get; set; }
        #endregion
    }
}
