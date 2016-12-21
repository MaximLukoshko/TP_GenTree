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
        Int32 mother;
        Int32 father;
        IModel locmodel;

        public AddForm(IModel model)
        {
            locmodel = model;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SetData(new Person());
        }

        private void SetData(Person infoPerson)
        {
            Person person = infoPerson;

            birthDateYearComboBox.SelectedIndex = person.BirthDateCorrectField[0] == true ? person.BirthDate.Year - 1919 : -1;
            birthDateMonthComboBox.SelectedIndex = person.BirthDateCorrectField[1] == true ? person.BirthDate.Month - 1 : -1;
            birthDateDayComboBox.SelectedIndex = person.BirthDateCorrectField[2] == true ? person.BirthDate.Day - 1 : -1;

            middleNameTextBox.Text = person.FirstName;
            firstNameTextBox.Text = person.SecondName;
            textBox15.Text = person.MotherSecondName;
            secondNameTextBox.Text = person.MiddleName;

            birthPlaceTextBox.Text = person.BirthPlace;

            deathDateYearComboBox.SelectedIndex = person.DeathDateCorrectField[0] == true ? person.DeathDate.Year - 1919 : -1;
            deathDateMonthComboBox.SelectedIndex = person.DeathDateCorrectField[1] == true ? person.DeathDate.Month - 1 : -1;
            deathDateDayComboBox.SelectedIndex = person.DeathDateCorrectField[2] == true ? person.DeathDate.Day - 1 : -1;

            deathDayTextBox.Text = person.DeathPlace;
            foreach (String educLine in person.Education)
                textBox18.Text += educLine + Environment.NewLine;
            father = person.Father;

            genderRadioButton.Checked = person.Gender;
            radioButton2.Checked = !person.Gender;

            foreach (String locLine in person.Location)
                textBox16.Text += locLine + Environment.NewLine;

            mother = person.Mother;
            nationalityTextBox.Text = person.Nationality;

            foreach (String profLine in person.Profession)
                textBox17.Text += profLine + Environment.NewLine;

            socialStatusTextBox.Text = person.SocialStatus;
            textBox12.Text = person.Note;
            dataSourceTextBox.Text = person.DataSource;
        }
        public AddForm(Person infoPerson)
        {
            InitializeComponent();
            SetData(infoPerson);

            // Блокируем возможность изменять анкету
            this.Enabled = false;
        }

        private Person GetData()
        {
            Person person = new Person();
            person.BirthDate = new DateTime(birthDateYearComboBox.SelectedIndex == -1 ? 1 : birthDateYearComboBox.SelectedIndex + 1919,
                birthDateMonthComboBox.SelectedIndex == -1 ? 1 : birthDateMonthComboBox.SelectedIndex + 1,
                birthDateDayComboBox.SelectedIndex == -1 ? 1 : birthDateDayComboBox.SelectedIndex + 1);
            
            person.BirthDateCorrectField[0] = birthDateYearComboBox.SelectedIndex != -1;
            person.BirthDateCorrectField[1] = birthDateMonthComboBox.SelectedIndex != -1;
            person.BirthDateCorrectField[2] = birthDateDayComboBox.SelectedIndex != -1;

            person.BirthPlace= birthPlaceTextBox.Text;
            person.DataSource = dataSourceTextBox.Text;
            person.DeathDate = new DateTime(deathDateYearComboBox.SelectedIndex == -1 ? 1 : deathDateYearComboBox.SelectedIndex + 1919,
                deathDateMonthComboBox.SelectedIndex == -1 ? 1 : deathDateMonthComboBox.SelectedIndex + 1,
                deathDateDayComboBox.SelectedIndex == -1 ? 1 : deathDateDayComboBox.SelectedIndex + 1);

            person.DeathDateCorrectField[0] = deathDateYearComboBox.SelectedIndex != -1;
            person.DeathDateCorrectField[1] = deathDateMonthComboBox.SelectedIndex != -1;
            person.DeathDateCorrectField[2] = deathDateDayComboBox.SelectedIndex != -1;

            person.DeathPlace = deathDayTextBox.Text;
            for (int i = 0; i < textBox18.Lines.Length - 1; i++)
                person.Education.Add(textBox18.Lines[i]);
            person.Father = father;
            person.FirstName = middleNameTextBox.Text;
            person.SecondName = firstNameTextBox.Text;
            person.MotherSecondName = textBox15.Text;
            person.MiddleName = secondNameTextBox.Text;
            person.Gender = genderRadioButton.Checked;
            person.IsGenderSet = genderRadioButton.Checked || radioButton2.Checked;
            for (int i = 0; i < textBox16.Lines.Length - 1; i++)
                person.Location.Add(textBox16.Lines[i]);
            person.Mother = mother;
            person.Nationality = nationalityTextBox.Text;
            for (int i = 0; i < textBox17.Lines.Length - 1; i++)
                person.Profession.Add(textBox17.Lines[i]);
            person.SocialStatus = socialStatusTextBox.Text;
            person.Note = textBox12.Text;
            person.DataSource = dataSourceTextBox.Text;
            return person;
        }
        //Добавление человека
        private void button1_Click(object sender, EventArgs e)
        {
            Person person = GetData();
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
            String LineToAdd = firstbox.ToString() + ") " + locationTextBox.Text + Environment.NewLine;
            textBox16.Text += LineToAdd;
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
            SetData(new Person());
        }
        //Подключение-отключение девичьей фамилии
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

        //Выбор мамы
        private void button6_Click(object sender, EventArgs e)
        {
            //2 for female, 1 fo male
            FindForm form = new FindForm(locmodel, true, false);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            if (form.DialogResult == DialogResult.OK)
            {
                mother = form.ReturnValue.Code;
                motherTextBox.Text = form.ReturnValue.ToString();
                form.Close();
            }

            
        }

        //Выбор папы
        private void button7_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(locmodel, true, true); 
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            if (form.DialogResult == DialogResult.OK)
            {
                father = form.ReturnValue.Code;
                fatherTextBox.Text = form.ReturnValue.ToString();
                form.Close();
            }
        }
    }
}
