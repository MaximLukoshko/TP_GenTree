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

        public AddForm(IModel model)
        {
            locmodel = model;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public AddForm(Person infoPerson)
        {
            InitializeComponent();
            person = infoPerson;
            birthDateYearComboBox.SelectedIndex = person.BirthDateCorrectField[0] == true ? person.BirthDate.Year - 1919 : -1;
            birthDateMonthComboBox.SelectedIndex = person.BirthDateCorrectField[1] == true ? person.BirthDate.Month : -1;
            birthDateDayComboBox.SelectedIndex = person.BirthDateCorrectField[2] == true ? person.BirthDate.Day : -1;

            middleNameTextBox.Text = person.FirstName;
            firstNameTextBox.Text = person.SecondName;
            textBox15.Text = person.MotherSecondName;
            secondNameTextBox.Text = person.MiddleName;

            this.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person = new Person();
            person.BirthDate = new DateTime(birthDateYearComboBox.SelectedIndex == -1 ? 1 : birthDateYearComboBox.SelectedIndex + 1919,
                birthDateMonthComboBox.SelectedIndex == -1 ? 1 : birthDateMonthComboBox.SelectedIndex + 1,
                birthDateDayComboBox.SelectedIndex == -1 ? 1 : birthDateDayComboBox.SelectedIndex + 1);
            
            person.BirthDateCorrectField[0] = birthDateYearComboBox.SelectedIndex != -1;
            person.BirthDateCorrectField[1] = birthDateMonthComboBox.SelectedIndex != -1;
            person.BirthDateCorrectField[2] = birthDateDayComboBox.SelectedIndex != -1;

            person.BirthPlace= birthPlaceTextBox.Text;
          //  person.Code =;
            person.DataSource = dataSourceTextBox.Text;
            person.DeathDate = new DateTime(deathDateYearComboBox.SelectedIndex == -1 ? 1 : deathDateYearComboBox.SelectedIndex + 1919,
                deathDateMonthComboBox.SelectedIndex == -1 ? 1 : deathDateMonthComboBox.SelectedIndex + 1,
                deathDateDayComboBox.SelectedIndex == -1 ? 1 : deathDateDayComboBox.SelectedIndex + 1);

            person.DeathDateCorrectField[0] = deathDateYearComboBox.SelectedIndex != -1;
            person.DeathDateCorrectField[1] = deathDateMonthComboBox.SelectedIndex != -1;
            person.DeathDateCorrectField[2] = deathDateDayComboBox.SelectedIndex != -1;

            person.DeathPlace = deathDayTextBox.Text;
            for(int i=0;i < educationTextBox.Lines.Length;i++)
                person.Education.Add(educationTextBox.Lines[i]);
            person.Father =father;
            person.FirstName = middleNameTextBox.Text;
            person.SecondName = firstNameTextBox.Text;
            person.MotherSecondName = textBox15.Text;
            person.MiddleName = secondNameTextBox.Text;
            person.Gender = genderRadioButton.Checked;
            person.IsGenderSet = genderRadioButton.Checked || radioButton2.Checked;
            for (int i = 0; i < locationTextBox.Lines.Length; i++)
                person.Location.Add(locationTextBox.Lines[i]);
            person.Mother =mother;
            person.Nationality = nationalityTextBox.Text;
            for (int i = 0; i < professionTextBox.Lines.Length; i++)
                person.Profession.Add(professionTextBox.Lines[i]);
            person.SocialStatus = socialStatusTextBox.Text;
            locmodel.AddPerson(ref person);
            MessageBox.Show("Анкета успешно добавлена.", "",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
        static int firstbox = 1;
        static int secbox = 1;
        static int thirdbox = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox16.Text += firstbox.ToString();
            textBox16.Text += ") "+locationTextBox.Text+ Environment.NewLine;
            locationTextBox.Clear();
            textBox16.SelectionStart = textBox16.TextLength-1;
            textBox16.ScrollToCaret();
            firstbox++;
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            textBox17.Text += secbox.ToString();
            textBox17.Text +=") "+ professionTextBox.Text + Environment.NewLine;
            professionTextBox.Clear();
            textBox17.SelectionStart = textBox17.TextLength - 1;
            textBox17.ScrollToCaret();
            secbox++;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox18.Text += thirdbox.ToString();
            textBox18.Text += ") "+educationTextBox.Text + Environment.NewLine;
            educationTextBox.Clear();
            textBox18.SelectionStart = textBox18.TextLength - 1;
            textBox18.ScrollToCaret();
            thirdbox++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Clear();
            professionTextBox.Clear();
            educationTextBox.Clear();
            textBox12.Clear();
            deathDayTextBox.Clear();
            dataSourceTextBox.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            middleNameTextBox.Clear();
            secondNameTextBox.Clear();
            locationTextBox.Clear();
            socialStatusTextBox.Clear();
            nationalityTextBox.Clear();
            birthPlaceTextBox.Clear();
            birthDateDayComboBox.Items.Clear();
            birthDateMonthComboBox.Items.Clear();
            birthDateYearComboBox.Items.Clear();
            deathDateYearComboBox.Items.Clear();
            deathDateMonthComboBox.Items.Clear();
            deathDateDayComboBox.Items.Clear();
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
            FindForm form = new FindForm(locmodel, ref mother, true, false);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(locmodel, ref mother, true, true); 
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }
    }
}
