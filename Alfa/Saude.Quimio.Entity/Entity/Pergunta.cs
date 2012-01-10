using System;
using System.Collections.Generic;
using Alfa.Core.Entity;
using System.Linq;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Pergunta : EntityBase
    {

        #region "Atributos"
        private IList<OpcaoResposta> opcoesDeResposta = new List<OpcaoResposta>();
        #endregion

        public Pergunta()
        {
        }
        public virtual int _Calculada { get; set; }
        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual bool? RespostaExclusiva { get; set; }
        public virtual int Ordem { get; set; }
        public virtual int Version { get; set; }
        public virtual IEnumerable<OpcaoResposta> OpcoesDeResposta
        {
            get { return opcoesDeResposta; }
            private set { opcoesDeResposta = value.ToList(); }

        }
        public virtual void AddOpcaoResposta(OpcaoResposta opcaoResposta)
        {
            opcoesDeResposta.Add(opcaoResposta);
            opcaoResposta.Pergunta = this;
        }
        public virtual void RemoveOpcaoResposta(OpcaoResposta opcaoResposta)
        {
            opcoesDeResposta.Remove(opcaoResposta);
        }

        #endregion

        public override IEnumerable<string> Validate()
        {
            if (Descricao == null) yield return "Descrição não informada.";
            if (RespostaExclusiva == null) yield return "Resposta exclusiva não informada.";
            if (Ordem == null) yield return "Ordem não informada.";
        }
    }
}
