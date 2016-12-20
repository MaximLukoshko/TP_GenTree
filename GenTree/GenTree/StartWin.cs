using Data;
using DatabaseModel.Model;
using howto_generic_treenode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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

            model = new Model();
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

        // The root node.
        private TreeNode<CircleNode> root = new TreeNode<CircleNode>(new CircleNode("Человек Откоторогорисуем",0));

        private void ArrangeTree()
        {
            using (Graphics gr = this.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = (this.ClientSize.Height - ymin) / 2;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            // Redraw.
            this.Refresh();
        }

        private void StartWin_Load(object sender, EventArgs e)
        {
            TreeNode<CircleNode> a_node =
                    new TreeNode<CircleNode>(new CircleNode("Сын Имя Фамилия",1));
            TreeNode<CircleNode> b_node =
                new TreeNode<CircleNode>(new CircleNode("Дочь Имя фамилия",1));

            root.AddChild(a_node);
            root.AddChild(b_node);

            // Arrange the tree.
            ArrangeTree();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }
    }
}
