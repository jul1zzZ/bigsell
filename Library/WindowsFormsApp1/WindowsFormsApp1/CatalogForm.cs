using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void catalogsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.catalogsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bookshopDataSet);

        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.catalogs". При необходимости она может быть перемещена или удалена.
            this.catalogsTableAdapter.Fill(this.bookshopDataSet.catalogs);

        }

        private void cat_nameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
