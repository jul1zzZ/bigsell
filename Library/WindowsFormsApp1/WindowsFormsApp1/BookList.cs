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
    public partial class BookList : Form
    {
        private System.Windows.Forms.DataGridViewColumn COL;
        public BookList()
        {
            InitializeComponent();
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.booksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bookshopDataSet);

        }

        private void BookList_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.bookshopDataSet.books);

        }

        private void bookshopDataSetBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonsort.Enabled = true;
        }

        private void buttonsort_Click(object sender, EventArgs e)
        {
            COL = new System.Windows.Forms.DataGridViewColumn();
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    COL = dataGridViewTextBoxColumn2;
                    break;
                case 1:
                    COL = dataGridViewTextBoxColumn3;
                    break;
                case 2:
                    COL = dataGridViewTextBoxColumn4;
                    break;
                case 3:
                    COL = dataGridViewTextBoxColumn5;
                    break;
                case 4:
                    COL = dataGridViewTextBoxColumn6;
                    break;
            }
            if (radioButton1.Checked)
                booksDataGridView.Sort(COL,
               System.ComponentModel.ListSortDirection.Ascending);
            else
                booksDataGridView.Sort(COL,
               System.ComponentModel.ListSortDirection.Descending);
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            booksBindingSource.Filter = "b_name='" + comboBoxName.Text + "'";
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            booksBindingSource.Filter = "";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < booksDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < booksDataGridView.RowCount - 1; j++)
                {
                    booksDataGridView[i, j].Style.BackColor = Color.White;
                    booksDataGridView[i, j].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < booksDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < booksDataGridView.RowCount - 1; j++)
                {
                    if (booksDataGridView[i,j].Value.ToString().IndexOf(textBoxCriteria.Text) != -1)
                    {
                        booksDataGridView[i, j].Style.BackColor = Color.AliceBlue;
                        booksDataGridView[i, j].Style.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
