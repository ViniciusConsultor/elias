using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alfa.Pet.Model;
using Alfa.Core;
using Alfa.Core.Container;
using Alfa.Core.Unit;

namespace Alfa.Pet.Win
{
    public partial class FormBase : Form
    {
        // ISession session = null;
        protected int ID
        {
            get;
            set;
        }
        public FormBase()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            //session = NHibernateSessionHelper<Cliente>.CreateSessionFactory().OpenSession();
            //session.BeginTransaction();

            //MessageBox.Show(
            //    Locator.GetComponet<IRepository<Produto>>().GetAll().Count().ToString());

            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnClosed(EventArgs e)
        {           
            //session.Transaction.Commit();
            base.OnClosed(e);
        }
        protected void Alerta(string mensagem, MessageBoxButtons icone)
        {
            MessageBox.Show(mensagem, "Pet System", icone);
        }
        protected void Alerta(string mensagem)
        {
            Alerta(mensagem, MessageBoxButtons.OK);
        }
    }
}
