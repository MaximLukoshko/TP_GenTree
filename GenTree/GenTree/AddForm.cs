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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Анкета успешно создана.\nНикуда добавлять мы её, конечно, не будем.", "",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        static int firstbox = 1;
        static int secbox = 1;
        static int thirdbox = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox16.Text += firstbox.ToString();
            textBox16.Text += ") "+textBox5.Text+ Environment.NewLine;
            textBox5.Clear();
            textBox16.SelectionStart = textBox16.TextLength-1;
            textBox16.ScrollToCaret();
            firstbox++;
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            textBox17.Text += secbox.ToString();
            textBox17.Text +=") "+ textBox10.Text + Environment.NewLine;
            textBox10.Clear();
            textBox17.SelectionStart = textBox17.TextLength - 1;
            textBox17.ScrollToCaret();
            secbox++;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox18.Text += thirdbox.ToString();
            textBox18.Text += ") "+textBox11.Text + Environment.NewLine;
            textBox11.Clear();
            textBox18.SelectionStart = textBox18.TextLength - 1;
            textBox18.ScrollToCaret();
            thirdbox++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox15.Enabled=false;
            label13.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox15.Enabled = true;
            label13.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //1 for female, 2 fo male, 3 for hz
            FindForm form = new FindForm(1);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(2);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }
    }
}
