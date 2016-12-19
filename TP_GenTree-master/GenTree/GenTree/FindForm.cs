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
    public partial class FindForm : Form
    {
        Person mask;
        IModel locmodel;
        public FindForm(Boolean gender,ref int parent,ref IModel model)
        {
            locmodel=model;
            InitializeComponent();
            if (!gender)
            {
                label14.Enabled = true;
                textBox9.Enabled = true;
            }
            if (gender)
            {
                label14.Enabled = false;
                textBox9.Enabled = false;
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            mask.FirstName = firstNameTextBox.Text;
            mask.MiddleName = middleNameTextBox.Text;
            mask.SecondName = secondNameTextBox.Text;
            mask.BirthPlace = birthPlaceTextBox.Text;
            mask.BirthDate = new DateTime(birthDateYearComboBox.SelectedIndex + 1919, birthDateMonthComboBox.SelectedIndex, birthDateDayComboBox.SelectedIndex);

            IDictionary<Int32, Person> _items =  locmodel.FindPeople(mask);

            resultListBox.DataSource = _items;
        }
    }
}
