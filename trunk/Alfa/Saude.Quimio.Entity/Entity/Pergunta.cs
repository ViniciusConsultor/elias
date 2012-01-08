using System;
using System.Collections.Generic;
using Alfa.Core.Entity;


namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Pergunta : EntityBase
    {

        #region "Atributos"
        private IList<OpcaoResposta> opcaoRespostaLista = new List<OpcaoResposta>();
        #endregion

        public Pergunta()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual bool? RespostaExclusiva { get; set; }
        public virtual int? Ordem { get; set; }
        public virtual int Version { get; set; }
        public virtual IList<OpcaoResposta> OpcaoRespostaLista
        {
            get { return this.opcaoRespostaLista; }
            set { this.opcaoRespostaLista = value; }
        }

        #endregion

        public override IEnumerable<string> Validate()
        {
            if (Descricao == null) yield return "Descrição não informada.";
        }
    }
}
