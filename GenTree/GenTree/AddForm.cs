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

            firstNameTextBox.Text = person.FirstName;
            secondNameTextBox.Text = person.SecondName;
            MotherSecondNameTextBox.Text = person.MotherSecondName;
            middleNameTextBox.Text = person.MiddleName;

            birthPlaceTextBox.Text = person.BirthPlace;

            deathDateYearComboBox.SelectedIndex = person.DeathDateCorrectField[0] == true ? person.DeathDate.Year - 1919 : -1;
            deathDateMonthComboBox.SelectedIndex = person.DeathDateCorrectField[1] == true ? person.DeathDate.Month - 1 : -1;
            deathDateDayComboBox.SelectedIndex = person.DeathDateCorrectField[2] == true ? person.DeathDate.Day - 1 : -1;

            deathDayTextBox.Text = person.DeathPlace;
            foreach (String educLine in person.Education)
                educationStack.Text += educLine + Environment.NewLine;
            father = person.Father;

            genderMaleRadioButton.Checked = person.Gender;
            genderFemaleRadioButton.Checked = !person.Gender;

            foreach (String locLine in person.Location)
                locationStack.Text += locLine + Environment.NewLine;

            mother = person.Mother;
            nationalityTextBox.Text = person.Nationality;

            foreach (String profLine in person.Profession)
                professionStack.Text += profLine + Environment.NewLine;

            socialStatusTextBox.Text = person.SocialStatus;
            Note.Text = person.Note;
            dataSourceTextBox.Text = person.DataSource;
        }
        public AddForm(Person infoPerson)
        {
            InitializeComponent();
            SetData(infoPerson);

            this.Text = GetData().ToString();

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
            for (int i = 0; i < educationStack.Lines.Length - 1; i++)
                person.Education.Add(educationStack.Lines[i]);
            person.Father = father;
            person.FirstName = firstNameTextBox.Text;
            person.SecondName = secondNameTextBox.Text;
            person.MotherSecondName = MotherSecondNameTextBox.Text;
            person.MiddleName = middleNameTextBox.Text;
            person.Gender = genderMaleRadioButton.Checked;
            person.IsGenderSet = genderMaleRadioButton.Checked || genderFemaleRadioButton.Checked;
            for (int i = 0; i < locationStack.Lines.Length - 1; i++)
                person.Location.Add(locationStack.Lines[i]);
            person.Mother = mother;
            person.Nationality = nationalityTextBox.Text;
            for (int i = 0; i < professionStack.Lines.Length - 1; i++)
                person.Profession.Add(professionStack.Lines[i]);
            person.SocialStatus = socialStatusTextBox.Text;
            person.Note = Note.Text;
            person.DataSource = dataSourceTextBox.Text;
            return person;
        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            Person person = GetData();
            String addInfo = locmodel.AddPerson(ref person);
            if (addInfo != "")
            {
                MessageBox.Show(addInfo, "Ошибка добавления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Анкета успешно добавлена.", "",
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
        static int firstbox = 1;
        static int secbox = 1;
        static int thirdbox = 1;
        private void locationButton_Click(object sender, EventArgs e)
        {
            String LineToAdd = firstbox.ToString() + ") " + locationTextBox.Text + Environment.NewLine;
            locationStack.Text += LineToAdd;
            locationTextBox.Clear();
            locationStack.SelectionStart = locationStack.TextLength-1;
            locationStack.ScrollToCaret();
            firstbox++;
        }
      
        private void professionAddButton_Click(object sender, EventArgs e)
        {
            professionStack.Text += secbox.ToString();
            professionStack.Text +=") "+ professionTextBox.Text + Environment.NewLine;
            professionTextBox.Clear();
            professionStack.SelectionStart = professionStack.TextLength - 1;
            professionStack.ScrollToCaret();
            secbox++;
        }
        private void educationAddButton_Click(object sender, EventArgs e)
        {
            educationStack.Text += thirdbox.ToString();
            educationStack.Text += ") "+educationTextBox.Text + Environment.NewLine;
            educationTextBox.Clear();
            educationStack.SelectionStart = educationStack.TextLength - 1;
            educationStack.ScrollToCaret();
            thirdbox++;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetData(new Person());
        }

        private void genderMale_CheckedChange(object sender, EventArgs e)
        {
            MotherSecondNameTextBox.Enabled = false;
            label13.Enabled = false;
        }

        private void genderFemale_CheckedChange(object sender, EventArgs e)
        {
            MotherSecondNameTextBox.Enabled = true;
            label13.Enabled = true;
        }

        private void addMotherButton_Click(object sender, EventArgs e)
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
                if (null != form.ReturnValue)
                {
                    mother = form.ReturnValue.Code;
                    motherTextBox.Text = form.ReturnValue.ToString();
                }
                form.Close();
            }

            
        }

        private void addFatherButton_Click(object sender, EventArgs e)
        {
            FindForm form = new FindForm(locmodel, true, true); 
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                form.Close();
            }
            if (form.DialogResult == DialogResult.OK)
            {
                if (null != form.ReturnValue)
                {
                    father = form.ReturnValue.Code;
                    fatherTextBox.Text = form.ReturnValue.ToString();
                }
                form.Close();
            }
        }

        private Boolean checkLetter(char l)
        {
            return !(l >= 'А' && l <= 'Я' || l >= 'а' && l <= 'я' || l >= 'A' && l <= 'Z' || l >= 'a' && l <= 'z' || l == 8);
        }

        private void secondNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkLetter(e.KeyChar);
        }

        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
