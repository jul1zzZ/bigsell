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
    public partial class BookForm : Form
    {
        public BookForm()
        {
            InitializeComponent();
        }

        private void booksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.booksBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bookshopDataSet);

        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.catalogs". При необходимости она может быть перемещена или удалена.
            this.catalogsTableAdapter.Fill(this.bookshopDataSet.catalogs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.bookshopDataSet.books);

        }

        private void b_authorLabel_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            booksBindingSource.RemoveCurrent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            booksBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            booksBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            booksBindingSource.MoveNext();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            booksBindingSource.MoveLast();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            booksBindingSource.AddNew();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //проверяет введённые в поля данные на соответствие типам данных полей
            this.Validate();
            //закрывает подключение с сервером
            this.booksBindingSource.EndEdit();
            //обновляет данные на сервере
            this.tableAdapterManager.UpdateAll(this.bookshopDataSet);
        }
        private BookList bookForm;

        private void button8_Click(object sender, EventArgs e)
        {
            bookForm = new BookList();
            bookForm.Visible = true;
        }
    }
}
