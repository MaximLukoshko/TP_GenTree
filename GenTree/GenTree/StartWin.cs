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
    public partial class StartWin : Form
    {

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;

        IModel model;

        public StartWin()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void новыйРодственникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(ref model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }

        private void человекаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 per=0;
            FindForm form = new FindForm(false,ref per, ref model);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
                form.Close();
        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void определитьРодствоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
