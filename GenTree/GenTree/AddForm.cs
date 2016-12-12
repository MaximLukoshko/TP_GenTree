using Data;
using DatabaseModel.Model;
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

        Person person;
        Int32 mother;
        Int32 father;
        IModel locmodel;

        public AddForm(ref IModel model)
        {
            locmodel = model;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.BirthDate = new DateTime(comboBox3.SelectedIndex+1919, comboBox2.SelectedIndex, comboBox1.SelectedIndex);
            person.BirthPlace= textBox8.Text;
          //  person.Code =;
            person.DataSource = textBox14.Text;
            person.DeathDate = new DateTime(comboBox4.SelectedIndex + 1919, comboBox5.SelectedIndex, comboBox6.SelectedIndex);
            person.DeathPlace = textBox13.Text;
            foreach (string s in textBox11.Lines)
                person.Education.Add(s);
            person.Father =father;
            person.FirstName = textBox1.Text;
            person.Gender =radioButton1.Checked;
            foreach (string s in textBox5.Lines)
                person.Location.Add(s);
            person.MiddleName = textBox2.Text;
            person.Mother =mother;
            person.Nationality = textBox7.Text;
            person.Note = textBox12.Text;
            foreach (string s in textBox10.Lines)
                person.Profession.Add(s);
            person.SecondName = textBox4.Text;
            person.SocialStatus = textBox6.Text;
            locmodel.AddPerson(person);
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
            //2 for female, 1 fo male
            FindForm form = new FindForm(false,ref mother,ref locmodel);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(true,ref father,ref locmodel);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }
    }
}
