using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alfa.Core.Container;
using Alfa.Pet.Model;
using Alfa.Core.Repository;
using Alfa.Core.Unit;

namespace Alfa.Pet.Win.paginas
{
    public partial class MarcaEdit : FormBase
    {
        public MarcaEdit()
        {
            InitializeComponent();
            this.Load += new EventHandler(MarcaEdit_Load);
            this.FormClosed += new FormClosedEventHandler(MarcaEdit_FormClosed);
        }
        public MarcaEdit(int pID)
        {
            InitializeComponent();
            Marca entity = Locator.GetComponet<IRepository<Marca>>().GetById(pID);
            textBox1.Text = entity.Descricao;
            ID = pID;
        }

        void MarcaEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locator.GetComponet<IUnitOfWork>().Commit();
        }

        void MarcaEdit_Load(object sender, EventArgs e)
        {
            Locator.GetComponet<IUnitOfWork>().BeginTransaction();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Locator.GetComponet<IUnitOfWork>().Rollback();
            Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Locator.GetComponet<IRepository<Marca>>().Save(BuildMarca());
            this.Close();
        }
        private Marca BuildMarca()
        {
            Marca entity = new Marca();
            if (ID != 0)
                entity = Locator.GetComponet<IRepository<Marca>>().GetById(ID);

            entity.Descricao = textBox1.Text;
            return entity;
        }        
    }
}
