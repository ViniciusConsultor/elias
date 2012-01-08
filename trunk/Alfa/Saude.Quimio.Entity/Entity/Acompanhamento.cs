using System;
using System.Collections.Generic;
using Alfa.Core.Entity;


namespace Saude.Quimio.Entity
{
    public partial class Acompanhamento : EntityBase
    {

        #region "Atributos"
        #endregion

        public Acompanhamento()
        {
        }

        #region "Propriedades"
        public virtual int? Id { get; private set; }
        public virtual DateTime? DataEncerramento { get; set; }
        public virtual string Observacao { get; set; }
        public virtual AcompanhamentoSituacao AcompanhamentoSituacao { get; set; }
        public virtual AcompanhamentoSituacao AcompanhamentoSituacaoNonoMes { get; set; }
        public virtual int Version { get; set; }
        #endregion
    }
}
