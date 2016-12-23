namespace GenTree
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.birthDateYearComboBox = new System.Windows.Forms.ComboBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.birthDateMonthComboBox = new System.Windows.Forms.ComboBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.birthDateDayComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.MotherSecondNameTextBox = new System.Windows.Forms.TextBox();
            this.MiddleNaneLabel = new System.Windows.Forms.Label();
            this.birthPlaceTextBox = new System.Windows.Forms.TextBox();
            this.secondNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonPreView = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelGender = new System.Windows.Forms.Label();
            this.checkBoxGenderMale = new System.Windows.Forms.CheckBox();
            this.checkBoxGenderFemale = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // resultListBox
            // 
            this.resultListBox.FormattingEnabled = true;
            this.resultListBox.Location = new System.Drawing.Point(297, 36);
            this.resultListBox.Name = "resultListBox";
            this.resultListBox.Size = new System.Drawing.Size(299, 186);
            this.resultListBox.Sorted = true;
            this.resultListBox.TabIndex = 11;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(504, 256);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(92, 23);
            this.acceptButton.TabIndex = 13;
            this.acceptButton.Text = "Подтвердить";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Месяц";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 258);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // birthDateYearComboBox
            // 
            this.birthDateYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.birthDateYearComboBox.FormattingEnabled = true;
            this.birthDateYearComboBox.Items.AddRange(new object[] {
            "1919",
            "1920",
            "1921",
            "1922",
            "1923",
            "1924",
            "1925",
            "1926",
            "1927",
            "1928",
            "1929",
            "1930",
            "1931",
            "1932",
            "1933",
            "1934",
            "1935",
            "1936",
            "1937",
            "1938",
            "1939",
            "1940",
            "1941",
            "1942",
            "1943",
            "1944",
            "1945",
            "1946",
            "1947",
            "1948",
            "1949",
            "1950",
            "1951",
            "1952",
            "1953",
            "1954",
            "1955",
            "1956",
            "1957",
            "1958",
            "1959",
            "1960",
            "1961",
            "1962",
            "1963",
            "1964",
            "1965",
            "1966",
            "1967",
            "1968",
            "1969",
            "1970",
            "1971",
            "1972",
            "1973",
            "1974",
            "1975",
            "1976",
            "1977",
            "1978",
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.birthDateYearComboBox.Location = new System.Drawing.Point(216, 201);
            this.birthDateYearComboBox.Name = "birthDateYearComboBox";
            this.birthDateYearComboBox.Size = new System.Drawing.Size(60, 21);
            this.birthDateYearComboBox.TabIndex = 9;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(125, 228);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(152, 23);
            this.buttonFind.TabIndex = 10;
            this.buttonFind.Text = "Найти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "День";
            // 
            // birthDateMonthComboBox
            // 
            this.birthDateMonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.birthDateMonthComboBox.FormattingEnabled = true;
            this.birthDateMonthComboBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.birthDateMonthComboBox.Location = new System.Drawing.Point(120, 201);
            this.birthDateMonthComboBox.Name = "birthDateMonthComboBox";
            this.birthDateMonthComboBox.Size = new System.Drawing.Size(90, 21);
            this.birthDateMonthComboBox.TabIndex = 8;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 40);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(29, 13);
            this.FirstNameLabel.TabIndex = 17;
            this.FirstNameLabel.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Год";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Место рождения";
            // 
            // birthDateDayComboBox
            // 
            this.birthDateDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.birthDateDayComboBox.FormattingEnabled = true;
            this.birthDateDayComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.birthDateDayComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.birthDateDayComboBox.Location = new System.Drawing.Point(75, 201);
            this.birthDateDayComboBox.Name = "birthDateDayComboBox";
            this.birthDateDayComboBox.Size = new System.Drawing.Size(39, 21);
            this.birthDateDayComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Дата рождения";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Девичья фамилия";
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(124, 118);
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.middleNameTextBox.TabIndex = 5;
            this.middleNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.middleNameTextBox_KeyPress);
            // 
            // MotherSecondNameTextBox
            // 
            this.MotherSecondNameTextBox.Location = new System.Drawing.Point(124, 92);
            this.MotherSecondNameTextBox.Name = "MotherSecondNameTextBox";
            this.MotherSecondNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.MotherSecondNameTextBox.TabIndex = 4;
            this.MotherSecondNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MotherSecondNameTextBox_KeyPress);
            // 
            // MiddleNaneLabel
            // 
            this.MiddleNaneLabel.AutoSize = true;
            this.MiddleNaneLabel.Location = new System.Drawing.Point(12, 121);
            this.MiddleNaneLabel.Name = "MiddleNaneLabel";
            this.MiddleNaneLabel.Size = new System.Drawing.Size(54, 13);
            this.MiddleNaneLabel.TabIndex = 20;
            this.MiddleNaneLabel.Text = "Отчество";
            // 
            // birthPlaceTextBox
            // 
            this.birthPlaceTextBox.Location = new System.Drawing.Point(124, 144);
            this.birthPlaceTextBox.Name = "birthPlaceTextBox";
            this.birthPlaceTextBox.Size = new System.Drawing.Size(152, 20);
            this.birthPlaceTextBox.TabIndex = 6;
            // 
            // secondNameTextBox
            // 
            this.secondNameTextBox.Location = new System.Drawing.Point(125, 63);
            this.secondNameTextBox.Name = "secondNameTextBox";
            this.secondNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.secondNameTextBox.TabIndex = 3;
            this.secondNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.secondNameTextBox_KeyPress);
            // 
            // SecondNameLabel
            // 
            this.SecondNameLabel.AutoSize = true;
            this.SecondNameLabel.Location = new System.Drawing.Point(11, 69);
            this.SecondNameLabel.Name = "SecondNameLabel";
            this.SecondNameLabel.Size = new System.Drawing.Size(56, 13);
            this.SecondNameLabel.TabIndex = 18;
            this.SecondNameLabel.Text = "Фамилия";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(124, 37);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.firstNameTextBox.TabIndex = 2;
            this.firstNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNameTextBox_KeyPress);
            // 
            // buttonPreView
            // 
            this.buttonPreView.Location = new System.Drawing.Point(297, 228);
            this.buttonPreView.Name = "buttonPreView";
            this.buttonPreView.Size = new System.Drawing.Size(299, 23);
            this.buttonPreView.TabIndex = 12;
            this.buttonPreView.Text = "Предварительный просмотр";
            this.buttonPreView.UseVisualStyleBackColor = true;
            this.buttonPreView.Click += new System.EventHandler(this.buttonPreView_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 228);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(98, 23);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(12, 9);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(27, 13);
            this.labelGender.TabIndex = 16;
            this.labelGender.Text = "Пол";
            // 
            // checkBoxGenderMale
            // 
            this.checkBoxGenderMale.AutoSize = true;
            this.checkBoxGenderMale.Location = new System.Drawing.Point(120, 9);
            this.checkBoxGenderMale.Name = "checkBoxGenderMale";
            this.checkBoxGenderMale.Size = new System.Drawing.Size(72, 17);
            this.checkBoxGenderMale.TabIndex = 0;
            this.checkBoxGenderMale.Text = "Мужской";
            this.checkBoxGenderMale.UseVisualStyleBackColor = true;
            this.checkBoxGenderMale.CheckedChanged += new System.EventHandler(this.checkBoxGenderMale_CheckedChanged);
            // 
            // checkBoxGenderFemale
            // 
            this.checkBoxGenderFemale.AutoSize = true;
            this.checkBoxGenderFemale.Location = new System.Drawing.Point(216, 8);
            this.checkBoxGenderFemale.Name = "checkBoxGenderFemale";
            this.checkBoxGenderFemale.Size = new System.Drawing.Size(73, 17);
            this.checkBoxGenderFemale.TabIndex = 1;
            this.checkBoxGenderFemale.Text = "Женский";
            this.checkBoxGenderFemale.UseVisualStyleBackColor = true;
            this.checkBoxGenderFemale.CheckedChanged += new System.EventHandler(this.checkBoxGenderFemale_CheckedChanged);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 288);
            this.Controls.Add(this.checkBoxGenderFemale);
            this.Controls.Add(this.checkBoxGenderMale);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonPreView);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.birthDateYearComboBox);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.birthDateMonthComboBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.birthDateDayComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.middleNameTextBox);
            this.Controls.Add(this.MotherSecondNameTextBox);
            this.Controls.Add(this.MiddleNaneLabel);
            this.Controls.Add(this.birthPlaceTextBox);
            this.Controls.Add(this.secondNameTextBox);
            this.Controls.Add(this.SecondNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.Text = "Поиск...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resultListBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox birthDateYearComboBox;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox birthDateMonthComboBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox birthDateDayComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.TextBox MotherSecondNameTextBox;
        private System.Windows.Forms.Label MiddleNaneLabel;
        private System.Windows.Forms.TextBox birthPlaceTextBox;
        private System.Windows.Forms.TextBox secondNameTextBox;
        private System.Windows.Forms.Label SecondNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button buttonPreView;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.CheckBox checkBoxGenderMale;
        private System.Windows.Forms.CheckBox checkBoxGenderFemale;
    }
}