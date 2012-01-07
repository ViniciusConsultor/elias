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
using Alfa.Task.Entity;
using Alfa.Core.Mapper;

namespace Alfa.Task
{
    public partial class frmAtividade : Form
    {
        public frmAtividade()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            Atividade atividade = new Atividade();
            Locator.GetComponet<IRepository<Atividade>>().Save(atividade);

            //FluentNHibernateConfigurationBuilder.Create();
            
            //bindingSource1.DataSource = Locator.GetComponet<IRepository<Atividade>>().GetAll().ToList();


            //textBox1.DataBindings.Add("Text", bindingSource1, "Descricao");

            //bindingNavigator1.BindingSource = bindingSource1;
            
        }

        private void frmAtividade_Load(object sender, EventArgs e)
        {

        }
        
    }
}
    