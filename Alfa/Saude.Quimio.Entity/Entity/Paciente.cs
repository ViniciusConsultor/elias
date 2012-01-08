using System;
using System.Collections.Generic;
using Alfa.Core.Entity;
using Saude.Quimio.Enum;

namespace Saude.Quimio.Entity
{

    /// <summary>
    /// 
    /// </summary> 

    public partial class Paciente : EntityBase
    {

        #region "Atributos"
        private IList<Endereco> enderecoList = new List<Endereco>();
        private IList<Notificacao> notificacaoList = new List<Notificacao>();
        #endregion

        public Paciente()
        {
        }

        #region "Propriedades"
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual string NomeMae { get; set; }
        public virtual DateTime? Nascimento { get; set; }
        public virtual int Version { get; set; }
        private int? mIdade;

        public virtual int? Idade
        {
            get
            {
                if (!Nascimento.HasValue)
                    return mIdade;
                return 0;
                //return Saude.Net.Util.Tempo.Periodo.duracaoDateTime(Nascimento.Value, DateTime.Now).Year;
            }
            set
            {
                mIdade = value;
            }
        }


        public virtual string Profissao { get; set; }
        public virtual string NumeroProntuario { get; set; }
        public virtual EnumSexo Sexo { get; set; }

        public virtual IList<Endereco> EnderecoLista
        {
            get { return this.enderecoList; }
            set { this.enderecoList = value; }
        }


        public virtual IList<Notificacao> NotificacaoLista
        {
            get { return this.notificacaoList; }
            set { this.notificacaoList = value; }
        }


        #endregion

    }
}
