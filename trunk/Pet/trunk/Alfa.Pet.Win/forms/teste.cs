﻿using System;
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
using Alfa.Core.Entity;
using Alfa.Core.Windows.Extension;

namespace Alfa.Pet.Win.forms
{
    public partial class teste : Form
    {
        public teste()
        {
            InitializeComponent();

            listView1.DataBind(
            Locator.GetComponet<IRepository<Marca>>().GetAll().ToList());


            if (listView1.Items.Count == 1)
                Locator.GetComponet<IRepository<Marca>>().InsertOnSubmit(
                    new Marca { Descricao = "teste" });

            listView1.DataBind(
           Locator.GetComponet<IRepository<Marca>>().GetAll().ToList());



            listView1.Width = 500;
            listView1.Columns[1].Width = 300;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }
    }
}
