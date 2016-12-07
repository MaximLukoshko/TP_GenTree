using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenTree
{
    public partial class FindForm : Form
    {
        public FindForm(int i)
        {
            InitializeComponent();
            if (i == 1)
            {
                label14.Enabled = true;
                textBox9.Enabled = true;
            }
            if (i == 2)
            {
                label14.Enabled = false;
                textBox9.Enabled = false;
            }
            if (i == 3)
            {
                label14.Enabled = true;
                textBox9.Enabled = true;
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<string> _items = new List<string>(); // <-- Add this


            _items.Add("Результат"); // <-- Add these
            _items.Add("Еще результат");
            _items.Add("( ͡° ͜ʖ ͡°)");

            listBox1.DataSource = _items;
        }
    }
}
