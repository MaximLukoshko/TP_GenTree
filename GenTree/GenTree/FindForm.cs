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
            mask = new Person();
            mask.FirstName = firstNameTextBox.Text;
            mask.MiddleName = middleNameTextBox.Text;
            mask.SecondName = secondNameTextBox.Text;
            mask.MotherSecondName = textBox9.Text;
            mask.BirthPlace = birthPlaceTextBox.Text;

            mask.BirthDate = new DateTime(birthDateYearComboBox.SelectedIndex == -1 ? 1 : birthDateYearComboBox.SelectedIndex + 1919,
                birthDateMonthComboBox.SelectedIndex == -1 ? 1 : birthDateMonthComboBox.SelectedIndex + 1,
                birthDateDayComboBox.SelectedIndex == -1 ? 1 : birthDateDayComboBox.SelectedIndex + 1);

            mask.BirthDateCorrectField[0] = birthDateYearComboBox.SelectedIndex != -1;
            mask.BirthDateCorrectField[1] = birthDateMonthComboBox.SelectedIndex != -1;
            mask.BirthDateCorrectField[2] = birthDateDayComboBox.SelectedIndex != -1;

            IDictionary<Int32, Person> _items =  locmodel.FindPeople(mask);
            IList<Person> tableSource = new List<Person>();

            foreach (Person person in _items.Values)
                tableSource.Add(person);
                //tableSource.Add(person.FirstName + " " + person.SecondName);

            resultListBox.DataSource = tableSource;
        }

        private void buttonPreView_Click(object sender, EventArgs e)
        {
            Person selected = (Person)resultListBox.SelectedItem;
            AddForm personInfo = new AddForm(selected);
            personInfo.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Text = "";
            middleNameTextBox.Text = "";
            secondNameTextBox.Text = "";
            textBox9.Text = "";
            birthPlaceTextBox.Text = "";
            birthDateYearComboBox.SelectedIndex = -1;
            birthDateMonthComboBox.SelectedIndex = -1;
            birthDateDayComboBox.SelectedIndex = -1;
        }
    }
}
