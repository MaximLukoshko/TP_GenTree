namespace GenTree
{
    partial class StartWin
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйРодственникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.человекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительныеВозможностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findRelationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.preViewButton = new System.Windows.Forms.Button();
            this.genTreelistBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.найтиToolStripMenuItem,
            this.дополнительныеВозможностиToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(932, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйРодственникToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // новыйРодственникToolStripMenuItem
            // 
            this.новыйРодственникToolStripMenuItem.Name = "новыйРодственникToolStripMenuItem";
            this.новыйРодственникToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.новыйРодственникToolStripMenuItem.Text = "Новый родственник..";
            this.новыйРодственникToolStripMenuItem.Click += new System.EventHandler(this.новыйРодственникToolStripMenuItem_Click);
            // 
            // найтиToolStripMenuItem
            // 
            this.найтиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.человекаToolStripMenuItem});
            this.найтиToolStripMenuItem.Name = "найтиToolStripMenuItem";
            this.найтиToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.найтиToolStripMenuItem.Text = "Найти";
            // 
            // человекаToolStripMenuItem
            // 
            this.человекаToolStripMenuItem.Name = "человекаToolStripMenuItem";
            this.человекаToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.человекаToolStripMenuItem.Text = "Родственника..";
            this.человекаToolStripMenuItem.Click += new System.EventHandler(this.человекаToolStripMenuItem_Click);
            // 
            // дополнительныеВозможностиToolStripMenuItem
            // 
            this.дополнительныеВозможностиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findRelationsToolStripMenuItem});
            this.дополнительныеВозможностиToolStripMenuItem.Name = "дополнительныеВозможностиToolStripMenuItem";
            this.дополнительныеВозможностиToolStripMenuItem.Size = new System.Drawing.Size(193, 20);
            this.дополнительныеВозможностиToolStripMenuItem.Text = "Дополнительные возможности";
            // 
            // findRelationsToolStripMenuItem
            // 
            this.findRelationsToolStripMenuItem.Enabled = false;
            this.findRelationsToolStripMenuItem.Name = "findRelationsToolStripMenuItem";
            this.findRelationsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.findRelationsToolStripMenuItem.Text = "Определить родство..";
            this.findRelationsToolStripMenuItem.Click += new System.EventHandler(this.определитьРодствоToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.preViewButton);
            this.splitContainer1.Panel1.Controls.Add(this.genTreelistBox);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
            this.splitContainer1.Size = new System.Drawing.Size(932, 491);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 2;
            // 
            // preViewButton
            // 
            this.preViewButton.Location = new System.Drawing.Point(-2, 419);
            this.preViewButton.Name = "preViewButton";
            this.preViewButton.Size = new System.Drawing.Size(305, 46);
            this.preViewButton.TabIndex = 1;
            this.preViewButton.Text = "Просмотр анкеты";
            this.preViewButton.UseVisualStyleBackColor = true;
            this.preViewButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // genTreelistBox
            // 
            this.genTreelistBox.FormattingEnabled = true;
            this.genTreelistBox.Location = new System.Drawing.Point(3, 6);
            this.genTreelistBox.Name = "genTreelistBox";
            this.genTreelistBox.Size = new System.Drawing.Size(300, 407);
            this.genTreelistBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(932, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StartWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 515);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MenuStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartWin";
            this.Text = "GenTree";
            this.Load += new System.EventHandler(this.StartWin_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйРодственникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem найтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem человекаToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem дополнительныеВозможностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findRelationsToolStripMenuItem;
        private System.Windows.Forms.ListBox genTreelistBox;
        private System.Windows.Forms.Button preViewButton;
    }
}

