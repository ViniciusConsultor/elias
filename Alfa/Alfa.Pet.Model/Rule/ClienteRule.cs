using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alfa.Core.Rule;
using Alfa.Core.Entity;
using Alfa.Core.Container;
using Alfa.Core.Repository;

namespace Alfa.Pet.Model.Rule
{
    public class ClienteRule : DefaultPersistenceRule<Cliente>
    {
        public ClienteRule() : base(new Cliente()) { }

        public override void OnSave(Cliente entity)
        {
            base.OnSave(entity);
            base.Validator.Assert(entity.Nascimento < DateTime.Now.AddYears(-18), "Menores de idade precisam ser acompanhados de seus responsáveis");
            base.Validator.Assert(entity.Nascimento > DateTime.Now.AddYears(-65), "Maiores de 65 anos devem vir acompanhados");

            base.Validator.Validate();

            base.Validator.Assert(
            Locator.GetComponet<IRepository<Cliente>>().GetAll().Count<Cliente>(cli => cli.Nome == entity.Nome) == 0,
            "Cliente já cadastrado", true);

        }

        public override void OnDelete(Cliente entity)
        {
            base.OnDelete(entity);
        }
    }
}
