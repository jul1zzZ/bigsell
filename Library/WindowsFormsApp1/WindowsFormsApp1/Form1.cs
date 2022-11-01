using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private BookForm bookForm;
        private CatalogForm catalogForm;
        private OrderForm orderForm;
        private OrderViewForm orderView;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bookForm = new BookForm();
            bookForm.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            catalogForm = new CatalogForm();
            catalogForm.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            orderForm = new OrderForm();
            orderForm.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            orderView = new OrderViewForm();
            orderView.Visible = true;
        }
    }
}
