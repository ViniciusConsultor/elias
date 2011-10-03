using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alfa.Core.Container;
using Alfa.Core.Repository;
using Alfa.Pet.Model;
using Alfa.Core.Unit;

namespace Alfa.Pet.Win.paginas
{
    public partial class MarcaManter : FormBase
    {
        public MarcaManter()
        {
            InitializeComponent();

            IRepository<Marca> rep = Locator.GetComponet<IRepository<Marca>>();

            Marca a = new Marca();
            rep.InsertOnSubmit(a);

            BuildTela();
        }
        private int GetID()
        {
            if (this.dgvMarca.SelectedRows.Count == 0) return 0;
            return Convert.ToInt32(this.dgvMarca.SelectedRows[0].Cells[0].Value);
        }
        private void dgvMarca_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ExibirFormCadastro(GetID());
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.Excluir(GetID());
            }
        }
        private void Excluir(int codigo)
        {
            if (codigo == 0) return;

            Locator.GetComponet<IUnitOfWork>().BeginTransaction();

            Marca entity = Locator.GetComponet<IRepository<Marca>>().GetById(codigo);
            Locator.GetComponet<IRepository<Marca>>().DeleteOnSubmit(entity);

            Locator.GetComponet<IUnitOfWork>().Commit();

            BuildTela();
            Alerta("Registro excluido com sucesso!");
        }
        private void ExibirFormCadastro(int codigo)
        {
            if (codigo == 0) return;

            MarcaEdit form = new MarcaEdit(codigo);
            form.ShowDialog();
        }
        private void BuildTela()
        {
            marcaBindingSource.DataSource = Locator.GetComponet<IRepository<Marca>>().GetAll().ToList();
            dgvMarca.Refresh();

            this.dgvMarca.AutoGenerateColumns = false;
            //this.dgvMarca.DataSource = this._profissaoList;
            this.dgvMarca.Select();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            MarcaEdit form = new MarcaEdit();
            form.ShowDialog();
            BuildTela();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ExibirFormCadastro(GetID());
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir(GetID());
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
