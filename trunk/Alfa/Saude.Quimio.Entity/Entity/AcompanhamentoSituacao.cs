using System;
using System.Collections.Generic;
using Alfa.Core.Entity;

namespace Saude.Quimio.Entity
{

    public partial class AcompanhamentoSituacao : EntityBase
    {

        #region "Atributos"

        #endregion

        public AcompanhamentoSituacao()
        {
            //todo: isto deve ser um enumerado
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual int Version { get; set; }
        #endregion
    }
}
