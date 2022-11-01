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
    public partial class OrderViewForm : Form
    {
        public OrderViewForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderViewForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bookshopDataSet.view_order". При необходимости она может быть перемещена или удалена.
            this.view_orderTableAdapter.Fill(this.bookshopDataSet.view_order);

        }

        private void o_timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void o_timeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //класс System.Convert позволяет преобразовывать несовместимые в C# типы данных
            textBoxCalculate.Text = Convert.ToString(Convert.ToDouble(b_priceTextBox.Text) *
            Convert.ToDouble(o_numberTextBox.Text));
        }

        private void b_priceTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
