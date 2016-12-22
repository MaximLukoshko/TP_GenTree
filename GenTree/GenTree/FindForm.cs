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
        private Person retPerson;
        public Person ReturnValue 
        { 
            get
            {
                return retPerson;
            } 
            
            set
            {
                retPerson = value;
            } 
        }

        public FindForm(IModel model, Boolean isGenderSet = false, Boolean gender = false)
        {
            locmodel=model;
            InitializeComponent();
            checkBoxGenderMale.Checked = true;
            checkBoxGenderFemale.Checked = true;
            if(isGenderSet)
            {
                checkBoxGenderFemale.Enabled = false;
                checkBoxGenderMale.Enabled = false;
                
                if (!gender)    //Девичья фамилия
                {
                    label14.Enabled = true;
                    MotherSecondNameTextBox.Enabled = true;
                    checkBoxGenderMale.Checked = false;
                }
                else
                {
                    checkBoxGenderFemale.Checked = false;
                }
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            FillResultBoxByMask();
            
        }

        //"Назад"
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Кнопка "Найти"
        private void buttonFind_Click(object sender, EventArgs e)
        {
           FillResultBoxByMask();
        }

        private void FillResultBoxByMask()
        {
            mask = new Person();
            mask.FirstName = firstNameTextBox.Text;
            mask.MiddleName = middleNameTextBox.Text;
            mask.SecondName = secondNameTextBox.Text;
            mask.MotherSecondName = MotherSecondNameTextBox.Text;


            mask.BirthPlace = birthPlaceTextBox.Text;

            mask.BirthDate = new DateTime(birthDateYearComboBox.SelectedIndex == -1 ? 1 : birthDateYearComboBox.SelectedIndex + 1919,
                birthDateMonthComboBox.SelectedIndex == -1 ? 1 : birthDateMonthComboBox.SelectedIndex + 1,
                birthDateDayComboBox.SelectedIndex == -1 ? 1 : birthDateDayComboBox.SelectedIndex + 1);

            mask.BirthDateCorrectField[0] = birthDateYearComboBox.SelectedIndex != -1;
            mask.BirthDateCorrectField[1] = birthDateMonthComboBox.SelectedIndex != -1;
            mask.BirthDateCorrectField[2] = birthDateDayComboBox.SelectedIndex != -1;

            mask.IsGenderSet = (checkBoxGenderMale.Checked && !checkBoxGenderFemale.Checked) ||
                (!checkBoxGenderMale.Checked && checkBoxGenderFemale.Checked);
            if (mask.IsGenderSet)
                mask.Gender = checkBoxGenderMale.Checked;

            IList<Person> tableSource = locmodel.FindPeople(mask);

            resultListBox.DataSource = tableSource;
        }
        private void buttonPreView_Click(object sender, EventArgs e)
        {
            Person selected = (Person)resultListBox.SelectedItem;
            if(null!=selected)
            {
                AddForm personInfo = new AddForm(selected);
                personInfo.Show();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Text = "";
            secondNameTextBox.Text = "";
            middleNameTextBox.Text = "";
            MotherSecondNameTextBox.Text = "";
            birthPlaceTextBox.Text = "";
            birthDateYearComboBox.SelectedIndex = -1;
            birthDateMonthComboBox.SelectedIndex = -1;
            birthDateDayComboBox.SelectedIndex = -1;
        }

        private void checkBoxGenderFemale_CheckedChanged(object sender, EventArgs e)
        {
            MotherSecondNameTextBox.Enabled = checkBoxGenderFemale.Checked ||
                (!checkBoxGenderFemale.Checked && !checkBoxGenderMale.Checked);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Person selected = (Person)resultListBox.SelectedItem;
            if (null != selected)
            {
                this.ReturnValue = selected;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void checkBoxGenderMale_CheckedChanged(object sender, EventArgs e)
        {
            MotherSecondNameTextBox.Enabled = checkBoxGenderFemale.Checked ||
                (!checkBoxGenderFemale.Checked && !checkBoxGenderMale.Checked);
        }

        private Boolean checkLetter(char l)
        {
            return !(l > 'А' && l < 'Я' || l > 'а' && l < 'я' || l > 'A' && l < 'Z' || l > 'a' && l < 'z' || l == 8);
        }
        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkLetter(e.KeyChar);
        }

        private void secondNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkLetter(e.KeyChar);
        }

        private void MotherSecondNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkLetter(e.KeyChar);
        }

        private void middleNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkLetter(e.KeyChar);
        }
    }
}
