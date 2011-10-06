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

            listView1.Width = 500;
            listView1.Columns[1].Width = 300;
        }
    }


}
