using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{

    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.bookshopDataSet.users);

        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bookshopDataSet);

        }

        private void u_nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void u_patronymicLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
